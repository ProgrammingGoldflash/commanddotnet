﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CommandDotNet.Example
{
    [Command(Name = "demo", Description = "Sample application for demonstration", ExtendedHelpText = "this is extended help text")]
    public class MyApplication
    {
        private bool _cjumped;
        private string _clevel;
        private int? _cfeets;
        private IEnumerable<string> _cfriends;
        private double _cheight;
        private bool? _clog;
        private string _cpassword;
        private int _ctimes;
        private string _cauthor;

        public Task<int> Interceptor (
            InterceptorExecutionDelegate next,
            [Option(Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor " +
                                  "incididunt ut labore et dolore magna aliqua. " +
                                  "Ut enim ad minim veniam, quis nostrud exercitation ullamco")]
            bool cjumped,             
            
            [Option(Description = "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia ")]
            int? cfeets, 
            
            [Option(Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium")]
            IEnumerable<string> cfriends, 
            
            [Option(Description = "doloremque laudantium, totam rem aperiam,")]
            double cheight, 
            
            bool? clog,
            
            string cpassword,
            
            [Option(Description = "doloremque laudantium, totam rem aperiam,")]
            DayOfWeek day,
            
            int ctimes = 343,
            
            [Option(Description = "laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in " +
                                  "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
                                  "Excepteur sint occaecat cupidatat non proident,")]
            string clevel = "default random text",
            
            string cauthor = "minima veniam")
        {
            _cjumped = cjumped;
            _clevel = clevel;
            _cfeets = cfeets;
            _cfriends = cfriends;
            _cheight = cheight;
            _clog = clog;
            _cpassword = cpassword;
            _ctimes = ctimes;
            _cauthor = cauthor;

            return next();
        }
        
        [Command(Description = "m makes someone jump", Name = "JUMP")]
        public void Jump(
            [Option(Description = "m did someone jump?")]
            bool mjumped, 
            
            string mlevel, 
            
            int? mfeets, 
            
            double mheight, 
            
            bool? mlog,
            
            string mpassword,
            
            int mtimes = 0, 
            
            string mauthor = "m john")
        {

            Console.WriteLine("Constructor params");
            Console.WriteLine(JsonConvert.SerializeObject(new
            {
                cjumped = _cjumped,
                clevel = _clevel,
                cfeets = _cfeets,
                cfriends = _cfriends,
                cheight = _cheight,
                clog = _clog,
                cauthor = _cauthor,
                ctimes = _ctimes
            }, Formatting.Indented));
            
            
            Console.WriteLine("Method params");
            Console.WriteLine(JsonConvert.SerializeObject(new
            {
                mjumped,
                mlevel,
                mfeets,
                mpassword,
                mheight,
                mlog,
                mauthor,
                mtimes
            }, Formatting.Indented));
        }
    }
}