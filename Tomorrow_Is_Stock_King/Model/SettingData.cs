﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;

namespace Tomorrow_Is_Stock_King.Model
{
    public class SettingData : INotifyPropertyChanged
    {
        private int level;
        public int Level
        {
            get { return level; }
            set { level = value; OnPropertyChanged("Level"); }
        }

        private int turnCnt;
        public int TurnCnt
        {
            get { return turnCnt; }
            set { turnCnt = value; OnPropertyChanged("TurnCnt"); }
        }


        // 추후의 사용을 위해 미리 구현
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private int information;
        public int Information
        {
            get { return information; }
            set { information = value; OnPropertyChanged("Information"); }
        }

        private int eventTarget;
        public int EventTarget
        {
            get { return eventTarget; }
            set { eventTarget = value; OnPropertyChanged("EventTarget"); }
        }

        private int eventNum;
        public int EventNum
        {
            get { return eventNum; }
            set { eventNum = value; OnPropertyChanged("EventNum"); }
        }

        private Dictionary<int, Pair> popUpEvent;
        public Dictionary<int, Pair> PopUpEvent
        {
            get { return popUpEvent; }
            set { popUpEvent = value; }
        }

        private Events[] _events;

        public Events[] _Events
        {
            get { return _events; }
            set { _events = value; OnPropertyChanged("_Events"); }
        }

        private string eventTitle;
        public string EventTitle
        {
            get { return eventTitle; }
            set { eventTitle = value; OnPropertyChanged("EventTitle"); }
        }

        private string eventImg;
        public string EventImg
        {
            get { return eventImg; }
            set { eventImg = value; OnPropertyChanged("EventImg"); }
        }

        private string eventContent;
        public string EventContent
        {
            get { return eventContent; }
            set { eventContent = value; OnPropertyChanged("EventContent"); }
        }

        private string eventCompany;
        public string EventCompany
        {
            get { return eventCompany; }
            set { eventCompany = value; OnPropertyChanged("EventCompany"); }
        }

        private int getIsGood;
        public int GetIsGood
        {
            get { return getIsGood; }
            set { getIsGood = value; OnPropertyChanged("GetIsGood"); }
        }


        public SettingData()
        {
            Level = 1;
            TurnCnt = 0;
            Information = 3;
            EventTarget = 0;
            EventNum = 0;
            EventCompany = "";
            GetIsGood = -1;
            popUpEvent = new Dictionary<int, Pair>();

            int turn = 5;
            // 몇턴에 어떤이벤트가 나오는지 미리 생성
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                // 0이면 좋은이벤트, 1이면 나쁜이벤트
                int isGood = random.Next(2);
                int company = random.Next(20);
                PopUpEvent.Add(turn + i * 10, new Pair(company, isGood));
            }

            _Events = new Events[4];
            _Events[0] = new Events
            {
                ImgSrc = "pack://application:,,,/Tomorrow_Is_Stock_King;component/Images/NewInvestI.png",
                Title = "큰손 투자자 투자하기로",
                Content = "에 큰손 투자자가 투자하기로 결정하였습니다."
            };

            _Events[1] = new Events
            {
                ImgSrc = "pack://application:,,,/Tomorrow_Is_Stock_King;component/Images/NewTechI.png",
                Title = "신기술 개발",
                Content = "이 혁신적인 새로운 기술을 개발하였습니다."
            };

            _Events[2] = new Events
            {
                ImgSrc = "pack://application:,,,/Tomorrow_Is_Stock_King;component/Images/FireD.png",
                Title = "본사 화재",
                Content = "본사에 큰 화재가 발생하였습니다."
            };

            _Events[3] = new Events
            {
                ImgSrc = "pack://application:,,,/Tomorrow_Is_Stock_King;component/Images/TechLeakD.png",
                Title = "핵심 기술 유출",
                Content = "의 핵심 기술이 유출되었습니다."
            };

            EventTitle = "";
            EventImg = "";
            EventContent = "";
        }  
    }
    public class Events
    {
        public string ImgSrc { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
