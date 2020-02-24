 void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            SpeechSynthesizer _synthesizer = new SpeechSynthesizer();
            _synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Senior);
            if (e.Result.Text == "yes" || e.Result.Text == "present") // e.Result.Text contains the recognized text
            {
                _synthesizer.Speak("Marked Present");
                proxy_lst.Add(true);
                
            }
            else if (e.Result.Text == "no" || e.Result.Text == "absent")
            {
                _synthesizer.Speak("Marked Absent");
                proxy_lst.Add(false);
            }
            _completed.Set();
            _synthesizer.Dispose();
            

        }
        static ManualResetEvent _completed = null;
       
        public async Task<ActionResult> AutoMark()
        {
            //Get List of Students
            return await Task.Run<ActionResult>(() =>
            {
                _completed = new ManualResetEvent(false);
                
                Grammar gr = new Grammar(new GrammarBuilder("yes"));
                Grammar gr1 = new Grammar(new GrammarBuilder("no"));
                Grammar gr2 = new Grammar(new GrammarBuilder("present"));
                Grammar gr3 = new Grammar(new GrammarBuilder("absent"));
                //Response
                SpeechSynthesizer _synthesizer = new SpeechSynthesizer();
                _synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
                string uname = (string)Session["UserName"];
                var section = _context.Instructors.Where(c => c.username == uname).FirstOrDefault();
                var students = _context.Students.Where(m => m.section == section.section).ToList();
                
               
                foreach (var student in students)
                {
                  
                    _synthesizer.Speak(student.name);
                    SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
                    gr.Name = "testGrammar";
                    _recognizer.LoadGrammar(gr);
                    _recognizer.LoadGrammar(gr1);
                    _recognizer.LoadGrammar(gr2);
                    _recognizer.LoadGrammar(gr3);
                    _recognizer.SetInputToDefaultAudioDevice();
                    _recognizer.RecognizeAsync(RecognizeMode.Multiple); 
                    _recognizer.SpeechRecognized += _recognizer_SpeechRecognized;
                    _completed.WaitOne();
                    _recognizer.Dispose();
                    _completed = new ManualResetEvent(false);
                }
                
               
                _synthesizer.Speak("Attendance has been taken! Thank You");
                _synthesizer.Dispose();
                if (true)
                {
                    string uname1 = (string)Session["UserName"];
                    var section1 = _context.Instructors.Where(c => c.username == uname1).FirstOrDefault();
                    var student1 = _context.Students.Where(m => m.section == section.section).ToList();
                    
                    
                    var data = new StudentViewModel
                    {
                        st_list = student1,
                        proxy_list = proxy_lst

                    };
                    return View("NewSheet", data);
                }
               
            });
        }