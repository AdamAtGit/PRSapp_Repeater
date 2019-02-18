using PRSapp.Classes.Extensions;
using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Windows.Media.SpeechSynthesis;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace PRSapp.Views.UserControls.AppFxs
{
    public sealed partial class RepeaterUserControl : UserControl
    {
        //Repeater Dispatcher Timer
        DispatcherTimer repeatDispTimer = new DispatcherTimer();
        TimeSpan interval;//hh, mm, ss
        int timesToTick;
        int i = 0;
        
        int repetitions;
        //Media Output Async 
        string ttsRaw = string.Empty;

        //stoping timer and speak async tasks inprogress
        CancellationTokenSource cts;

        public RepeaterUserControl()
        {
            this.InitializeComponent();
            TimerSetUp();
        }

        public void TimerSetUp()
        {
            repeatDispTimer.Tick += RepeatDispTimer_Tick;
            ////repeatDispTimer.Interval = interval;
            Debug.WriteLine("TimerSetUp" + repeatDispTimer.IsEnabled.ToString());
        }

        private void RepeatDispTimer_Tick(object sender, object e)
        {
            Debug.WriteLine("RepeatDispTimer_Tick\n" + "i = " + i.ToString());
            Debug.WriteLine(repeatDispTimer.IsEnabled.ToString());
            Debug.WriteLine(timesToTick.ToString());
            BtnRepeatMediaOutAsync_Click(this, new RoutedEventArgs());
        }

        private async void BtnRepeatMediaOutAsync_Click(object sender, RoutedEventArgs e)
        {
            BtnRepeatMediaOutAsync.Visibility = Visibility.Collapsed;
            BtnStopPauseRepeatMediaOutAsync.Visibility = Visibility.Visible;
            if(TgsRepeats.IsOn)
            {
                Debug.Write("Hit tgsReapeats.IsOn//when is true");
            }
            else
            {
                Debug.Write("Hit tgsReapeats.IsOn//when is false");
            }
            repetitions = Convert.ToInt32(boxRepetitions.Text.Trim());
            if (i == 0)
            {

                int intervalinSecs = Convert.ToInt32(boxInterval.Text.Trim());
                interval = new TimeSpan(0, 0, intervalinSecs);
                repeatDispTimer.Interval = interval;
                timesToTick = (repetitions - 1);
            }        
         
            BtnRepeatMediaOutAsync.Foreground = new SolidColorBrush(Windows.UI.Colors.Orange);
            ttsRaw = boxTtsRaw.Text.Trim();
            try
            {
                await SpeakTextAsync(ttsRaw, uiMediaElement);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
            }

            //Start Repeater Timer
            repeatDispTimer.Start();
            Debug.WriteLine("BtnRepeatMediaOutAsync_Click" + timesToTick.ToString());
            Debug.WriteLine("i = " + i.ToString());

            //Stop timer when reps are complete
            i++;
            if (i > timesToTick)
            {
                repeatDispTimer.Stop();
                BtnRepeatMediaOutAsync.Visibility = Visibility.Collapsed;
                BtnStopPauseRepeatMediaOutAsync.Visibility = Visibility.Visible;
                i = 0;
                BtnRepeatMediaOutAsync.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
            }
            Debug.WriteLine(repeatDispTimer.IsEnabled.ToString());
        }

        #region Speech
        async Task<IRandomAccessStream> SynthesizeTextToSpeechAsync(string text)
        {
            // Windows.Storage.Streams.IRandomAccessStream
            IRandomAccessStream stream = null;

            // Windows.Media.SpeechSynthesis.SpeechSynthesizer
            using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            {
                // Windows.Media.SpeechSynthesis.SpeechSynthesisStream
                stream = await synthesizer.SynthesizeTextToStreamAsync(text);
            }
            return (stream);
        }

        async Task SpeakTextAsync(string text, MediaElement mediaElement,CancellationToken token)
        {
            //TODO: ARS use link below to stop async tasks
            //https://stackoverflow.com/questions/15614991/simply-stop-an-async-method
           
            BtnStopPauseRepeatMediaOutAsync.Visibility = Visibility.Visible;
            BtnRepeatMediaOutAsync.Visibility = Visibility.Collapsed;
            
            IRandomAccessStream stream = await this.SynthesizeTextToSpeechAsync(text);

            await mediaElement.PlayStreamAsync(stream, true);
        }
        #endregion

        private void BtnStopPauseRepeatMediaOutAsync_Click(object sender, RoutedEventArgs e)
        {
            i = 0;
            repeatDispTimer.Stop();
            BtnRepeatMediaOutAsync.Visibility = Visibility.Visible;
            BtnStopPauseRepeatMediaOutAsync.Visibility = Visibility.Collapsed;           
            BtnRepeatMediaOutAsync.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);        

        }
    }
}
