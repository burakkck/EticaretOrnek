using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeonTicaret.WebUI.Models;

namespace ZeonTicaret.WebUI.App_Classes
{
    public class Context
    {
        private static EticaretContext baglanti;

        public static EticaretContext Baglanti
        {
            get
            {
                if (baglanti == null)
                {
                    baglanti = new EticaretContext();
                }
                return baglanti;
            }
            set { baglanti = value; }
        }

    }
}