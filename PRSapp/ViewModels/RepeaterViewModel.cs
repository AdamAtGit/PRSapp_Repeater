using PRSapp.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSapp.ViewModels 
{
   public class RepeaterViewModel : INotifyPropertyChanged
    {
        public RepeatMediaOutAsyncCommand RepeatMediaOutAsyncCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public RepeaterViewModel()
        {
            RepeatMediaOutAsyncCommand = new RepeatMediaOutAsyncCommand(this);
        }

        public void RepeatMediaOutAsync(string content)
        {
            //BtnRepeatMediaOutAsync.Visibility = Visibility.Collapsed;
            //BtnStopPauseRepeatMediaOutAsync.Visibility = Visibility.Visible;
            //if (TgsRepeats.IsOn)
            //{
            //    Debug.Write("Hit tgsReapeats.IsOn//when is true");
            //}
            //else
            //{
            //    Debug.Write("Hit tgsReapeats.IsOn//when is false");
            //}
            //repetitions = Convert.ToInt32(boxRepetitions.Text.Trim());
            //if (i == 0)
            //{

            //    int intervalinSecs = Convert.ToInt32(boxInterval.Text.Trim());
            //    interval = new TimeSpan(0, 0, intervalinSecs);
            //    repeatDispTimer.Interval = interval;
            //    timesToTick = (repetitions - 1);
            //}

            //BtnRepeatMediaOutAsync.Foreground = new SolidColorBrush(Windows.UI.Colors.Orange);
            //ttsRaw = boxTtsRaw.Text.Trim();
            //try
            //{
            //    await SpeakTextAsync(ttsRaw, uiMediaElement);
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex.Message.ToString());
            //}

            ////Start Repeater Timer
            //repeatDispTimer.Start();
            //Debug.WriteLine("BtnRepeatMediaOutAsync_Click" + timesToTick.ToString());
            //Debug.WriteLine("i = " + i.ToString());

            ////Stop timer when reps are complete
            //i++;
            //if (i > timesToTick)
            //{
            //    repeatDispTimer.Stop();
            //    BtnRepeatMediaOutAsync.Visibility = Visibility.Collapsed;
            //    BtnStopPauseRepeatMediaOutAsync.Visibility = Visibility.Visible;
            //    i = 0;
            //    BtnRepeatMediaOutAsync.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
            //}


            //private void OnPropertyChanged(string propName)
            //{
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("propName"));
            //}
        }
    }
}
