﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Weigan.Loopview;
using System.Collections.Generic;
using System.Linq;

namespace CustomControls
{
    [Activity(Label = "CustomControls", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IOnItemSelectedListener
    {
        int count = 1;
        private Toast toast;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            string test = Java.Lang.String.Format(GetString(Resource.String.test), "test");

            LoopView loopView = (LoopView)FindViewById(Resource.Id.loopView);
            LoopView loopView1 = (LoopView)FindViewById(Resource.Id.loopView1);
            LoopView loopView2 = (LoopView)FindViewById(Resource.Id.loopView2);
            LoopView loopView3 = (LoopView)FindViewById(Resource.Id.loopView3);
            List<string> list = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                list.Add(i.ToString());
            }

            ////设置是否循环播放
            loopView.SetNotLoop();
            loopView.Id = 1;
            loopView.SetListener(this);
            loopView.SetItems(list);

            loopView1.SetNotLoop();
            loopView1.Id = 2;
            loopView1.SetItems(list);
            loopView1.SetListener(this);

            loopView2.SetNotLoop();
            loopView2.Id = 3;
            loopView2.SetItems(new List<string> { "公斤", "磅" });
            loopView2.SetListener(this);

            loopView3.SetNotLoop();
            loopView3.Id = 4;
            loopView3.SetItems(list);
            loopView3.SetListener(this);
        }

        public void OnItemSelected(LoopView p0, int p1)
        {
            string msg = "0";
            switch (p0.Id)
            {
                case 1:
                    msg = "item1";
                    break;
                case 2:
                    msg = "item2";
                    break;
                case 3:
                    msg = "item3";
                    break;
            }
            if (toast == null)
            {
                toast = Toast.MakeText(this, "item " + p0, ToastLength.Short);
            }
            toast.SetText(msg + p1);
            toast.Show();
        }
    }
}

