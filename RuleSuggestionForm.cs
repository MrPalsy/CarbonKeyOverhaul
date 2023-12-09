using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using OpenAI_API;

namespace CarbonKeyOverhaul {
    public partial class RuleSuggestionForm : Form {
        private AiConversation ai;
        public RuleSuggestionForm() {
            //tjek sql connnector class.
            InitializeComponent();
            this.ai = new AiConversation();
        }

        private async void SuggestBtn_Click(object sender, EventArgs e) {
            string userInput = InputTb.Text;
            string response = await ai.GetResponse(userInput);
            SuggestedRuleTb.Text = response;
          
        }


    }
}
