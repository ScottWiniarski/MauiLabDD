namespace MauiLabDD
{
    public partial class MainPage : ContentPage
    {
        int truths = 0;
        int falsehoods = 0;

        Dictionary<string, string> Questions = new Dictionary<string, string>();

        List<Question> questionList = new List<Question>();
        //List<Question> questionsList = new List<Question>();
        List<Boolean> answerList = new List<Boolean>();

        List<Question> results = new List<Question>();
        
        
        public MainPage()
        {
            InitializeComponent();

            BindingContext=this;
            Questions.Add("I prefer to handle my problems at a distance", "dotnet_bot.svg");
            //questionList.Add(new Question { image = new Image { Source = "cat.png" }, Text = "I handle my problems, at a distance." });
            //questionList.Add(new Question { image = new Image { Source = ImageSource.FromFile("dog.png") }, Text = "I prefer to settle conflicts personally." });
            //questionList.Add(new Question { Image = "dotnet_bot.svg", Text = "Take the behavioral test" });
            questionList.Add(new Question { Image = "archery.png", 
                Text = "I like to handle my problems from a distance." });
            questionList.Add(new Question { Image = "personal.png", 
                Text = "I'd prefer not to settle conflicts personally." });
            questionList.Add(new Question { Image = "lockpick.png" , 
                Text = "A clever hand is preferable over a daft one." });
            questionList.Add(new Question { Image =  "leadbyexample.png" , 
                Text = "I lead by example, good or bad." });
            questionList.Add(new Question { Image =  "doingmypart.png" , 
                Text = "I prefer to be a cog in the machine." });

            QuizImage.Source = "confuseddwarf.png";
            QuestionLabel.Text = "What Deep Rock Galactic Dwarf are you?";

            results.Add(new Question { Image = "engineer.png", 
                Text = "You sound like an Engineer!" });
            results.Add(new Question { Image = "gunner.png", 
                Text = "You sound like a Gunner!"});
            results.Add(new Question { Image = "scout.png", 
                Text = "You sound like a Scout!"});
            results.Add(new Question { Image = "driller.png", 
                Text = "You sound like a Driller!"});
            results.Add(new Question { Image = "management.png",
                Text = "You sound perfect for Management!"});
        }

        int count = 0;

        private void ConfirmClicked(object sender, EventArgs e)
        {
            Confirm.Text = "Continue";
            False.IsVisible = true;
            True.IsVisible = true; 
            if (answerList.Count < 5)
            {
                if (True.IsChecked == true)
                {
                    answerList.Add(true);
                    QuizImage.Source = questionList[count].Image;
                    QuestionLabel.Text = questionList[count].Text;
                    count++;
                    /*TestOutput.Text += "true ";
                    foreach (var answer in answerList)
                    {
                        TestOutput.Text += answer;
                    }
                    */
                }
                else
                {
                    answerList.Add(false);
                    QuizImage.Source = questionList[count].Image;
                    QuestionLabel.Text = questionList[count].Text;
                    count++;
                    /*
                    TestOutput.Text += "false ";
                    */
                }
            }
            else
            {
                // TODO The first click on confirm button does work, but does not advance the page.

                //QuizImage.Source = "dotnet_bot.png";
                //QuestionLabel.Text = "Ok, you're done";
                if (answerList[1] == true && answerList[2] == false && answerList[3] == true)
                {
                    QuizImage.Source = results[0].Image;
                    QuestionLabel.Text = results[0].Text;
                    TestOutput.Text = answerList.Count.ToString();
                }
                else if (answerList[1] == false && answerList[2] == true && answerList[3] == false)
                {
                    QuizImage.Source = results[3].Image;
                    QuestionLabel.Text = results[3].Text;
                    TestOutput.Text = answerList.Count.ToString();
                }
                else if (answerList[1] == true && answerList[2] == true && answerList[3] == false)
                {
                    QuizImage.Source = results[1].Image;
                    QuestionLabel.Text = results[1].Text;
                    TestOutput.Text = answerList.Count.ToString();
                }
                else if (answerList[1] == true && answerList[2] && answerList[3])
                {
                    QuizImage.Source = results[2].Image;
                    QuestionLabel.Text= results[2].Text;
                    TestOutput.Text = answerList.Count.ToString();
                }
                else
                {
                    QuizImage.Source = results[4].Image;
                    QuestionLabel.Text = results[4].Text;
                    TestOutput.Text = answerList.Count.ToString();
                }
            }   
        }

        private void ClearAnswers(object sender, EventArgs e)
        {
            answerList.Clear();
            TestOutput.Text = answerList.Count.ToString();
            count = 0;
            QuizImage.Source = "confuseddwarf.png";
            QuestionLabel.Text = "What Deep Rock Galactic Dwarf are you?";
            Confirm.Text = "Begin";
            False.IsVisible = false;
            True.IsVisible = false;

        }

        private void OnClicked(object sender, EventArgs e)
        {
            if (TheText.Text != "Dog")
            {
                TheImage.Source = "cat.png";
                TheText.Text = "Dog";
            }
            else
            {
                TheImage.Source = "dog.png";
                TheText.Text = "Cat";
            }
        }

        private void TrueClicked(object sender, EventArgs e)
        {
            truths++;
            TheText.Text = sender.GetType().Name;
        }
        private void FalseClicked(object sender, EventArgs e)
        {
            falsehoods++;
            TheText.Text = e.ToString();
        }
    }
}