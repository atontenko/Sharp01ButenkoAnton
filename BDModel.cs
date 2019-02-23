using System;

namespace Sharp01ButenkoAnton
{
    class BDModel
    {
        private DateTime _inputDateTime;
        internal bool IsValid { get; private set; }
        internal string Age { get; private set; }
        internal string WesternZodiac { get; private set; }
        internal string EasternZodiac { get; private set; }

        internal BDModel()
        {
            _inputDateTime=DateTime.Today;
        }

        internal DateTime Calculations
        {
            get => _inputDateTime;
            set
            {
                _inputDateTime = value;
                var ages = DateTime.Today.Year - value.Year - (value.DayOfYear > DateTime.Today.DayOfYear ? 1 : 0);
                var days = DateTime.Today - value;

                IsValid = ages >= 0 && ages <= 135;
                if (IsValid)
                {
                    Age = ages > 0 ? ages + " year(s)" : days.Days + " day(s)";
                    EasternZodiac = CalculateEasternZodiacSign();
                    WesternZodiac = CalculateWesternZodiacSign();
                }
            }
        }

        private string CalculateEasternZodiacSign()
        {
            string[] easternZodiaсs =
            {
                "",            //0
                "Rat",         //1
                "Ox",          //2
                "Tiger",       //3
                "Rabbit",      //4
                "Dragon",      //5
                "Snake",       //6
                "Horse",       //7
                "Goat",        //8
                "Monkey",      //9
                "Rooster",     //10
                "Dog",         //11
                "Pig"          //12
            };

            int id = (_inputDateTime.Year + 8) % 12;

            return easternZodiaсs[++id];
        }

        private string CalculateWesternZodiacSign()
        {
            string[] westernZodiaсs = {
                "",            //0
                "Aries",       //1
                "Taurus",      //2
                "Gemini",      //3
                "Cancer",      //4
                "Leo",         //5
                "Virgo",       //6
                "Libra",       //7
                "Scorpio",     //8
                "Sagittarius", //9
                "Capricorn",   //10
                "Aquarius",    //11
                "Pisces"       //12
            };

            int id = CalculateWesternZodiacId();

            return westernZodiaсs[id];
        }

        private int CalculateWesternZodiacId()
        {
            switch (_inputDateTime.Month)
            {
                case 1:                                      //January
                    if (_inputDateTime.Day <= 20) return 10;
                    return 11;
                case 2:                                      //February
                    if (_inputDateTime.Day <= 19) return 11;
                    return 12;
                case 3:                                      //March
                    if (_inputDateTime.Day <= 20) return 12;
                    return 1;
                case 4:                                      //April
                    if (_inputDateTime.Day <= 20) return 1;
                    return 2;
                case 5:                                      //May
                    if (_inputDateTime.Day <= 21) return 2;
                    return 3;
                case 6:                                      //June
                    if (_inputDateTime.Day <= 22) return 3;
                    return 4;
                case 7:                                      //July
                    if (_inputDateTime.Day <= 22) return 4;
                    return 5;
                case 8:                                      //August
                    if (_inputDateTime.Day <= 23) return 5;
                    return 6;
                case 9:                                      //September
                    if (_inputDateTime.Day <= 23) return 7;
                    return 8;
                case 10:                                      //October
                    if (_inputDateTime.Day <= 23) return 8;
                    return 9;
                case 11:                                      //November
                    if (_inputDateTime.Day <= 22) return 9;
                    return 10;
                case 12:                                      //December
                    if (_inputDateTime.Day <= 21) return 10;
                    return 11;
                default:
                    return 0;
            }
        }

        public bool IsBirthday
        {
            get
            {
                var today = DateTime.Today;
                return today.Month == _inputDateTime.Month && today.Day == _inputDateTime.Day;
            }
        }
    }
}

