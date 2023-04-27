using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Module3Lab2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            False.IsVisible = true;
            True.IsVisible = true;
            questionText.IsVisible = true;
            questionText.Text = "text";
            ShowNextQuetion();
        }

        int quizPoints = 0;
        bool? quizAnswer = null;
        int i = 0;

        List<Question> QuizQuestions = new List<Question>()
        { 
            new Question { QuizQuestion="The sky is blue.", CorrectAnswer=true },
            new Question { QuizQuestion="Grass is green.", CorrectAnswer=true },
            new Question { QuizQuestion="2 + 2 = 5.", CorrectAnswer=false},
            new Question { QuizQuestion="Smoking is good for you.", CorrectAnswer=false},
            new Question { QuizQuestion="A bear sh*ts in the woods.", CorrectAnswer=true}
        };
        void ClickedTrue(object sender, EventArgs e)
        {
            quizAnswer = true;
            if (i < QuizQuestions.Count() && QuizQuestions[i].CorrectAnswer == true)
            {
                i += 1;
                quizPoints += 1;
            }
            else
            {
                i += 1;
            }
            ShowNextQuetion();
        }

        void ClickedFalse(object sender, EventArgs e)
        {
            quizAnswer = false;
            if (i < QuizQuestions.Count() && QuizQuestions[i].CorrectAnswer == false)
            {
                quizPoints += 1;
                i += 1;
            }
            else 
            {
               i += 1;
            }
            ShowNextQuetion();
        }

        public void ShowNextQuetion()
        {
            if (i < QuizQuestions.Count())
            {
                questionText.Text = QuizQuestions[i].QuizQuestion;
            } else if (i >= QuizQuestions.Count())
            {
                False.IsVisible = false;
                True.IsVisible = false;
                questionText.Text = $"You scored {quizPoints}/5!";
            }
        }

    }
}
