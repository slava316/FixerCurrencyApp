using System;
using System.Windows.Forms;
using System.IO;

namespace FixerCurrencyApp
{
    public partial class MainForm : Form
    {
        private const string ApiKeyFileName = "apikey.txt";

        private FixerApiService _apiService;
        private FixerResponse _latestData;

        public MainForm()
        {
            InitializeComponent();
            LoadApiKeyFromFile();
        }

        private void LoadApiKeyFromFile()
        {
            try
            {
                if (File.Exists(ApiKeyFileName))
                {
                    string secretKey = File.ReadAllText(ApiKeyFileName).Trim();
                    txtApiKey.Text = secretKey;
                }
                else
                {
                    MessageBox.Show("Файл конфигурации apikey.txt не найден.\n\nПожалуйста, введите ваш персональный API-ключ от сервиса Fixer.io вручную в текстовое поле.",
                                    "Инструкция",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось прочитать файл API-ключа: {ex.Message}", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnLoadData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApiKey.Text))
            {
                MessageBox.Show("Введите API ключ Fixer.io", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _apiService = new FixerApiService(txtApiKey.Text);
                _latestData = await _apiService.GetLatestRatesAsync();

                if (_latestData.Success)
                {
                    cmbTargetCurrency.Items.Clear();
                    foreach (var currency in _latestData.Rates.Keys)
                    {
                        cmbTargetCurrency.Items.Add(currency);
                    }
                    if (cmbTargetCurrency.Items.Count > 0) cmbTargetCurrency.SelectedIndex = 0;

                    MessageBox.Show("Данные успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Ошибка API: {_latestData.Error.Info}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сети: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (_latestData == null || cmbTargetCurrency.SelectedItem == null) return;

            if (double.TryParse(txtAmount.Text, out double amount))
            {
                string target = cmbTargetCurrency.SelectedItem.ToString();
                double rate = _latestData.Rates[target];
                double result = amount * rate;

                lblResult.Text = $"{amount} EUR = {result:F2} {target}";
            }
            else
            {
                MessageBox.Show("Введите корректное число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnGetHistory_Click(object sender, EventArgs e)
        {
            if (_apiService == null)
            {
                MessageBox.Show("Сначала введите API ключ и инициализируйте сервис!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string formattedDate = dtpHistoryDate.Value.ToString("yyyy-MM-dd");

            try
            {
                var historicalData = await _apiService.GetHistoricalRatesAsync(formattedDate);
                if (historicalData.Success)
                {
                    lstHistoryResult.Items.Clear();
                    lstHistoryResult.Items.Add($"--- Курсы на {formattedDate} (База: EUR) ---");

                    string[] basicCurrencies = { "USD", "RUB", "GBP", "JPY", "CNY" };
                    foreach (var code in basicCurrencies)
                    {
                        if (historicalData.Rates.ContainsKey(code))
                        {
                            lstHistoryResult.Items.Add($"1 EUR = {historicalData.Rates[code]:F2} {code}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Ошибка: {historicalData.Error.Info}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка запроса истории: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}