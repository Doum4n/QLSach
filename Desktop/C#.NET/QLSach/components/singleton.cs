﻿using QLSach.components;
using QLSach.controllers;
using QLSach.database;
using QLSach.dbContext;
using QLSach.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashBoard = QLSach.view.DashBoard;

namespace QLSach.component
{
    internal class Singleton
    {
        private static Singleton? instance;
        private static readonly object lockObj = new object();
        //database
        private readonly Context db;
        //Mainframe
        private readonly MainFrameHelper mainFrameHelper;
        //Intilize From
        private readonly FormInitilize initilize;

        public loadImage LoadImg { get; }

        public Node State { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }

        public RegisterHelper RegisterHelper { get; set; }
        public AdminHelper AdminHelper { get; set; }

        public Singleton()
        {
            db = new();
            mainFrameHelper = new();
            initilize = new();
            LoadImg = new();
            RegisterHelper = new RegisterHelper();
            AdminHelper = new AdminHelper();
        }

        public static Singleton getInstance
        {
            get
            {
                lock (lockObj)
                {
                    instance ??= new();
                    return instance;
                }
            }
        }

        public Context Data { get { return db; } }
        public MainFrameHelper MainFrameHelper { get { return mainFrameHelper; } }
        public FormInitilize Initilize { get { return initilize; } }

    }

}
