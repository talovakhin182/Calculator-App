using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator_App
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        string operation;
        double firstNumber, secondNumber;
        int operationState = 0; //0 for no numbers, 1 for firstnumber given, 2 for second number input

        public MainPage()
        {
            InitializeComponent();
        }

        //Called when NUMBER buttons are clicked
        void OnClickNumber(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            string clicked = bt.Text;

            if (this.inputText.Text == "0")
            {
                this.inputText.Text = "";
            }

            if (operationState == 1)
            {
                this.inputText.Text = "";
                operationState = 2;
            }
            if (clicked == ".")
            {
                if (!this.inputText.Text.Contains("."))
                {
                    this.inputText.Text += clicked;
                }
            }
            else
            {
                this.inputText.Text += clicked;
            }
        }

        //Called when OPERATION buttons are clicked
        void OnClickOperation(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            string clicked = bt.Text;
            operation = clicked;
            if (this.inputText.Text == "")
            {
                firstNumber = 0;
            }
            else
            {
                firstNumber = Double.Parse(this.inputText.Text);
            }
            operationState = 1;
        }

        //Called when CLEAR button is clicked
        void OnClickClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            this.inputText.Text = "0";
            operationState = 0;
        }

        //Called when PERCENT button is clicked
        void OnClickPercent(object sender, EventArgs e)
        {
            double result = double.Parse(this.inputText.Text);
            result /= 100;
            this.inputText.Text = result.ToString();
            firstNumber = result;
            operationState = 1;
        }

        //Called when DELETE button is clicked
        void OnClickDelete(object sender, EventArgs e)
        {
            if (this.inputText.Text != "")
            {
                if (this.inputText.Text == "Math Error")
                {
                    this.inputText.Text = "";
                }
                else
                {
                    string given = this.inputText.Text;
                    string newGiven = given.Substring(0, given.Length - 1);
                    this.inputText.Text = newGiven;
                }
            }
        }

        //Called when EQUALS button is clicked
        void OnClickCalculate(object sender, EventArgs e)
        {
            double result;
            if (operationState == 2)
            {
                secondNumber = double.Parse(this.inputText.Text);
                result = Calculate();
                if (result == double.PositiveInfinity)
                {
                    this.inputText.Text = "Math Error";
                    firstNumber = 0;
                    operationState = 0;
                }
                else
                {
                    this.inputText.Text = result.ToString();
                    firstNumber = result;
                    operationState = 1;
                }
            }
        }

        //Calculate function used to calculate
        double Calculate()
        {
            double result = 0;
            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "x":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber == 0)
                    {
                        result = double.PositiveInfinity;
                    }
                    else
                    {
                        result = firstNumber / secondNumber;
                    }
                    break;
            }
            return result;
        }
    }
}
