using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShapeCanvas2.SlideUserControl
{
    /// <summary>
    /// Interaction logic for slideusercontrol.xaml
    /// </summary>
    public partial class slideusercontrol : UserControl
    {
        public static Brush y = new SolidColorBrush();
        ///CHANGE NOTIFICATION
        public event PropertyChangedEventHandler PropertyChanged;


        private string fieldName;

        public string FieldName
        {
            get { return fieldName; }
            set
            {
                fieldName = value;

                FieldChanged();
            }
        }


        protected void FieldChanged([CallerMemberName] string field = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(field));
            }
        }

        public slideusercontrol()
        {
            InitializeComponent();
        }
        public void ColorSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color color = Color.FromArgb((byte)slColorA.Value, (byte)slColorR.Value, (byte)slColorG.Value, (byte)slColorB.Value);
            //Color color = Color.FromRgb((byte)slColorR.Value, (byte)slColorG.Value, (byte)slColorB.Value);
            y = new SolidColorBrush(color);
            rect.Fill = y;
            //rect.Fill = new SolidColorBrush(color);

        }
        private void ChageCanvas_Click(object sender, RoutedEventArgs e)
        {
            Can1.Background = y;
         //   Can.Background = y;
        }

        List<Rectangle> rectremove = new List<Rectangle>();
        List<Ellipse> ellremove = new List<Ellipse>();

        public static Random rand = new Random();



        public void Clear_Click(object sender, RoutedEventArgs e)
        {
            Can1.Children.Clear();
        }

        public static int select;
        public void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Random r = new Random();
            Shape Rendershape = null;
            select = rand.Next(1, 3);
            if (select == 1)
            {
                Rendershape = new Rectangle();
                Rendershape.MouseLeftButtonDown += rect_MouseLeftButtonDown;
                Rendershape.MouseRightButtonDown += Can1_MouseRightButtonDown;
                Rendershape.Width = rand.Next(5, 60);
                Rendershape.Height = rand.Next(5, 60);
                Rendershape.Stroke = new SolidColorBrush(Colors.Black);
                Rendershape.Fill = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
              (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
                ///Point p = e.GetPosition(this);
                Point MousePos_Point = new Point();

                MousePos_Point = Mouse.GetPosition(Can1);
                // double x = p.X;
                //double y = p.Y;
                //p.X = Convert.ToDouble(e.GetPosition(Can1));
                //p.Y = Convert.ToDouble(e.GetPosition(Can1));
                //var pt = e.GetPosition(Can1);

                Canvas.SetLeft(Rendershape, e.GetPosition(Can1).X - (Rendershape.Width / 2.0));
                Canvas.SetTop(Rendershape, e.GetPosition(Can1).Y - (Rendershape.Height / 2.0));
                //Canvas.SetLeft(rect, MousePos_Point.X);
                //Canvas.SetTop(rect, MousePos_Point.Y);
                Can1.Children.Add(Rendershape);
                //rectremove.Add(rect);
            }
            else if (select == 2)
            {
                Rendershape = new Ellipse();
                Rendershape.MouseLeftButtonDown += rect_MouseLeftButtonDown;
                Rendershape.MouseRightButtonDown += Can1_MouseRightButtonDown;
                Rendershape.Width = rand.Next(5, 60);
                Rendershape.Height = rand.Next(5, 60);
                Rendershape.Stroke = new SolidColorBrush(Colors.Black);
                Rendershape.Fill = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
              (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
                ///Point p = e.GetPosition(this);
                Point MousePos_Point = new Point();

                MousePos_Point = Mouse.GetPosition(Can1);
                // double x = p.X;
                //double y = p.Y;
                //p.X = Convert.ToDouble(e.GetPosition(Can1));
                //p.Y = Convert.ToDouble(e.GetPosition(Can1));
                //var pt = e.GetPosition(Can1);

                Canvas.SetLeft(Rendershape, e.GetPosition(Can1).X - (Rendershape.Width / 2.0));
                Canvas.SetTop(Rendershape, e.GetPosition(Can1).Y - (Rendershape.Height / 2.0));
                //Canvas.SetLeft(rect, MousePos_Point.X);
                //Canvas.SetTop(rect, MousePos_Point.Y);
                Can1.Children.Add(Rendershape);
                //Ellipse ell = new Ellipse();
                //ell.MouseLeftButtonDown += rect_MouseLeftButtonDown;
                //ell.MouseRightButtonDown += Can1_MouseRightButtonDown;
                //ell.Width = rand.Next(5, 60);
                //ell.Height = rand.Next(5, 60);

                //ell.Stroke = new SolidColorBrush(Colors.Black);
                //ell.Fill = new SolidColorBrush(Colors.WhiteSmoke);
                //Point p2 = e.GetPosition(this);
                //double x = p2.X;
                //double y = p2.Y;
                ////p.X = Convert.ToDouble(e.GetPosition(Can1));
                ////p.Y = Convert.ToDouble(e.GetPosition(Can1));
                ////var pt = e.GetPosition(Can1);

                //Canvas.SetLeft(ell, x);
                //Canvas.SetTop(ell, y);
                //Can1.Children.Add(new UIElement() { Uid = "Text" });
                //Can1.Children.Add(ell);
                //ellremove.Add(ell);
            }
            //initialize properties
            //Add Event like
            //rectangle.MouseLeftButtonDown += rectangle_MouseLeftButtonDown;
        }
        public void rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // var rect = sender as System.Windows.Shapes.Rectangle;
            //var ell = sender as Ellipse;            
            // do whatever
        }

        public void Can1_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.GetPosition(Can1);
            //Can1.Children.Remove();
            // Retrieve the coordinate of the mouse position.
            Point pt = e.GetPosition((UIElement)sender);

            // Perform the hit test against a given portion of the visual object tree.
            HitTestResult result = VisualTreeHelper.HitTest(Can1, pt);

            if (result != null)
            {
                Can1.Children.Remove((UIElement)sender);
                // Perform action on hit visual object.
            }


        }

        //public void FillRectangle()
        //{

        //    Color c = new Color();
        //    c.A = 255;
        //    c.R = Convert.ToByte(slColorR.Value);
        //    c.G = Convert.ToByte(slColorG.Value);
        //    c.B = Convert.ToByte(slColorB.Value);
        //    Brush b = new SolidColorBrush(c);
        //    rect.Fill = b;
        //}
    }
}
