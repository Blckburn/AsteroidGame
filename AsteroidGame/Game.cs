﻿using AsteroidGame.VisualObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Game
    {
        /// <summary>Таймаут отрисовки одной сцены</summary>
        private const int __FrameTimeout = 10;

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        public static int Width { get; set; }

        public static int Height { get; set; }

        //static Game()
        //{
        //
        //}

        public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;


            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            var timer = new Timer { Interval = __FrameTimeout };
            timer.Tick += OnTimerTick;
            timer.Start();

        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        private static VisualObject[] __GameObjects;
        private static Bullet __Bullet;
        public static void Load()
        {

            var game_objects = new List<VisualObject>();
            var rnd = new Random();

            const int stars_count = 150;
            const int star_size = 5;
            const int star_max_speed = 20;
            for (var i = 0; i < stars_count; i++)
                game_objects.Add(new Star(
                new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                new Point(-rnd.Next(0, star_max_speed), 0),
                star_size));


            const int ellipses_count = 20;
            const int ellipses_size_x = 20;
            const int ellipses_size_y = 30;

            for (var i = 0; i < ellipses_count; i++)
                game_objects.Add(new EllipseObject(
                      new Point(600, i * 20),
                      new Point(15 - i, 20 - i),
                      new Size(ellipses_size_x, ellipses_size_y)));


            const int asteriods_count = 10;
            const int asteriod_size = 25;
            const int asteriod_max_speed = 20;
            for (var i = 0; i < asteriods_count; i++)
                game_objects.Add(new Asteroid(
                new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                new Point(-rnd.Next(0, asteriod_max_speed), 0),
                asteriod_size));



            //   var image = Properties.Resources.Asteroid;
            //   var image_object = new ImageObject(new Point(4, 7), new Point(-4, 6), new Size(20, 20), image);

            __GameObjects = game_objects.ToArray();
            __Bullet = new Bullet(200);

        }

        public static void Draw()
        {
            var g = __Buffer.Graphics;
            g.Clear(Color.Black);

            //g.DrawRectangle(Pens.White, new Rectangle(50, 50, 200, 200));
            //g.FillEllipse(Brushes.Red, new Rectangle(100, 50, 70, 120));

            foreach (var visual_object in __GameObjects)
                visual_object.Draw(g);

            __Bullet.Draw(g);

            __Buffer.Render();
        }

        public static void Update()
        {
            foreach (var visual_object in __GameObjects)
                visual_object.Update();

            __Bullet.Update();
            if (__Bullet.Position.X > Width)
                __Bullet = new Bullet(300);
        }

    }
}
