    /* C# Program to Demonstrate Multilevel Inheritance       */  
    using System;        
	using System.Collections.Generic;
            {
            }
            {
               inheri obj = new inheri();
                obj.mode();
                obj.feature();
                obj.Noise();
                Console.Read();
            }
        }
        class Mode
        {
            public void mode()
            {
                Console.WriteLine("There are Many Modes of Transport !!");
            }
        }
        class vehicle : Mode
        {
            public void feature()
            {
                Console.WriteLine("They Mainly Help in Travelling !!");
            }
        }
    }