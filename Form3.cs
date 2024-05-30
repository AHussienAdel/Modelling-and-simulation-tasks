using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using NewspaperSellerModels;
namespace MultiQueueSimulation
{
    public partial class Form2 : Form
    {
        private SimulationSystem simulationSystem;

        private string path;

        public Form2(SimulationSystem system, string path)
        {
            InitializeComponent();
            this.simulationSystem = system;
            this.path = path;

        }

        private void RunSimulationButton_Click(object sender, EventArgs e)
        {
            DisplayResultsInDataGridView();
            DisplayPerformanceMetrics();
        }

        private void DisplayResultsInDataGridView()
        {
            // Assuming you have a form with a DataGridView named dataGridView1
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Add columns to DataGridView
            dataGridView1.Columns.Add("DayNo", " DayNo");
            dataGridView1.Columns.Add("RandomNewsDayType", " RandomNewsDayType");
            dataGridView1.Columns.Add("RandomDemand", " RandomDemand");
            dataGridView1.Columns.Add("Demand", "Demand ");
            dataGridView1.Columns.Add("SalesProfit", "  SalesProfit ");
            dataGridView1.Columns.Add("LostProfit", "LostProfit ");
            dataGridView1.Columns.Add("ScrapProfit", " ScrapProfit");
            dataGridView1.Columns.Add("DailyNetProfit", "DailyNetProfit ");
           
            // Add rows to DataGridView
            foreach (var simulationCase in simulationSystem.SimulationTable)
            {

                dataGridView1.Rows.Add(
               simulationCase.DayNo,
               simulationCase.RandomNewsDayType,
               simulationCase.NewsDayType,
               simulationCase.RandomDemand,
               simulationCase.Demand,
               simulationCase.SalesProfit,
               simulationCase.LostProfit,
               simulationCase.ScrapProfit,
               simulationCase.DailyNetProfit
               )
           ;
            }


            dataGridView1.Refresh();

        }
        private void DisplayPerformanceMetrics()
        {


            TotalSalesProfit.Text = simulationSystem.PerformanceMeasures.TotalSalesProfit.ToString();
            TotalCost.Text = simulationSystem.PerformanceMeasures.TotalCost.ToString();
            TotalLostProfit.Text = simulationSystem.PerformanceMeasures.TotalLostProfit.ToString();
            TotalScrapProfit.Text = simulationSystem.PerformanceMeasures.TotalScrapProfit.ToString();
            TotalNetProfit.Text = simulationSystem.PerformanceMeasures.TotalNetProfit.ToString();
            DaysWithMoreDemand.Text = simulationSystem.PerformanceMeasures.DaysWithMoreDemand.ToString();
            DaysWithUnsoldPapers.Text = simulationSystem.PerformanceMeasures.DaysWithUnsoldPapers.ToString();
        }

   
        private void testcase1_Click(object sender, EventArgs e)
        {
            DisplayResultsInDataGridView();
        }

     
        private void button1_Click_1(object sender, EventArgs e)
        {
            DisplayPerformanceMetrics();
    }
    }
}