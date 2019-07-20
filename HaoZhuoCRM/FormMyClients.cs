using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormMyClients : Form
    {
        public FormMyClients()
        {
            InitializeComponent();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            FormClient frmClient = new FormClient();
            DialogResult dialogResult = frmClient.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {

            }
            frmClient.Close();
        }

        private void FormMyClients_Load(object sender, EventArgs e)
        {
            IList<ProvinceDto> provinces = RegionService.getAllProvinces();
            provinces.Insert(0, new ProvinceDto(string.Empty, String.Empty));
            //注意：一定先指定 ValueMember 和 DisplayMember 再设定 DataSource 否则提前触发 CmbProvinces_SelectedIndexChanged
            cmbProvinces.ValueMember = "provinceId";
            cmbProvinces.DisplayMember = "provinceName";
            cmbProvinces.DataSource = provinces;

        }

        private void CmbProvinces_SelectedIndexChanged(object sender, EventArgs e)
        {
            var provinceIdObj = cmbProvinces.SelectedValue;
            if (provinceIdObj == null)
            {
                cmbCities.DataSource = null;
                cmbCities.Items.Clear();
                return;
            }
            var provinceId = provinceIdObj.ToString();
            if (String.IsNullOrEmpty(provinceId))
            {
                cmbCities.DataSource = null;
                cmbCities.Items.Clear();
                return;
            }
            var cities = RegionService.getCitiesByProviceId(provinceId);
            cities.Insert(0, new CityDto(String.Empty, String.Empty));
            cmbCities.ValueMember = "CityId";
            cmbCities.DisplayMember = "cityName";
            cmbCities.DataSource = cities;
        }

        private void CmbCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj = cmbCities.SelectedValue;
            if (obj == null)
            {
                cmbCounties.DataSource = null;
                cmbCounties.Items.Clear();
                return;
            }
            var cityId = obj.ToString();
            if (String.IsNullOrEmpty(cityId))
            {
                cmbCounties.DataSource = null;
                cmbCounties.Items.Clear();
                return;
            }
            var counties = RegionService.getCountiesByCityId(cityId);
            counties.Insert(0, new CountyDto(String.Empty, String.Empty));
            cmbCounties.ValueMember = "countyId";
            cmbCounties.DisplayMember = "countyName";
            cmbCounties.DataSource = counties;
            return;

        }

        private void ButReset_Click(object sender, EventArgs e)
        {
            cmbProvinces.SelectedIndex = 0;
        }
    }
}
