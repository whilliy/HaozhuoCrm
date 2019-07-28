using System;
using System.Collections.Generic;

namespace Haozhuo.Crm.Service.Dto
{
    public class Genders
    {
        private static readonly object obj = new object();

        public static Gender MALE = new Gender(1, "男");
        public static Gender FEMALE = new Gender(2, "女");
        public static Gender NONE = new Gender(0, "未知");

        private static IList<Gender> all;
        private static IDictionary<Int32, String> dicGender;

        public static IList<Gender> ALL
        {
            get
            {
                if (all == null)
                {
                    lock (obj)
                    {
                        if (all == null)
                        {
                            InitGenders();
                        }
                    }

                }
                return all;
            }
        }

        public static IList<Gender> ALL_COPY
        {
            get
            {
                IList<Gender> genders = new List<Gender>();
                foreach (Gender g in ALL)
                {
                    genders.Add(g);
                }
                return genders;
            }
        }

        public static IDictionary<Int32, String> DIC_GENDER
        {
            get
            {
                if (dicGender == null)
                {
                    lock (obj)
                    {
                        if (dicGender == null)
                        {
                            InitGenders();
                        }
                    }
                }
                return dicGender;
            }
        }


        private static void InitGenders()
        {
            all = new List<Gender>();
            all.Add(NONE);
            all.Add(MALE);
            all.Add(FEMALE);
            dicGender = new Dictionary<Int32, String>();
            dicGender.Add(NONE.id, NONE.name);
            dicGender.Add(MALE.id, MALE.name);
            dicGender.Add(FEMALE.id, FEMALE.name);
        }
    }
}
