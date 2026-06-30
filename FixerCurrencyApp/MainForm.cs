using System;
using System.Windows.Forms;

namespace FixerCurrencyApp
{
    public partial class MainForm : Form
    {
        private FixerApiService _apiService;
        private FixerResponse _latestData;

        public MainForm()
        {
            InitializeComponent();
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
    }
}