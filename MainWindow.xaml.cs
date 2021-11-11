using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

namespace TestVolna {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        void test() {
            Polyline line = new Polyline();
            PointCollection polygonPoints = new PointCollection();

            double w = canvas.ActualWidth;
            double h = canvas.ActualHeight;

            double wc = w / 2;
            double hc = h / 2;

            for (double x = 0; x <= w; x += 0.5) {

                double x100 = 2 * Math.PI * x / 100;

                double y = 30 * Math.Sin(x100*2) + hc;

                polygonPoints.Add(new Point(x, y));
            }

            line.Stroke = new SolidColorBrush(Colors.Green);
            line.StrokeThickness = 0.5;
            line.Points = polygonPoints;

            canvas.Children.Add(line);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            WindowState = System.Windows.WindowState.Maximized;

            canvas.Children.Clear();





            PointCollection polygonPoints = new PointCollection();

            double w = canvas.ActualWidth;
            double h = canvas.ActualHeight;

            double wc = w / 2;
            double hc = h / 2;

            Polyline ox = new Polyline();
            ox.Stroke = new SolidColorBrush(Colors.Gray);
            ox.StrokeThickness = 0.5;
            ox.Points = new PointCollection();
            ox.Points.Add(new Point(0, hc));
            ox.Points.Add(new Point(w, hc));
            canvas.Children.Add(ox);

            int max = 100;

            PointCollection[] points = new PointCollection[max+1];
            for (int i = 0; i <= max; i++) {
                points[i] = new PointCollection();
            }

            for (double x = 0; x <= w; x+=0.5) {

                double x100 = 2 * Math.PI * x / 3;

                //var ff = Math.Sin(x);

                double ysum = 0;

                for(int i = 0; i <= max; i++) {
                    var prc = (double)i / max;
                    var delt = Convert.ToDouble(txt_dk.Text.Replace(".", ","));
                    var y = Math.Sin(x100 * (1 + delt * prc));
                    points[i].Add(new Point(x, y+hc));
                    ysum += y;
                }

                var cury = ysum / max * 3 * 30 + hc;
                Debug.WriteLine(cury);
                polygonPoints.Add(new Point(x, cury));
            }

            //for (int i = 0; i <= max; i++) {
            //    Polyline cur = new Polyline();
            //    cur.Stroke = new SolidColorBrush(Colors.Blue);
            //    cur.StrokeThickness = 0.5;
            //    cur.Points = points[i];
            //    canvas.Children.Add(cur);
            //}

            Polyline line = new Polyline();
            line.Stroke = new SolidColorBrush(Colors.Red);
            line.StrokeThickness = 2;
            line.Points = polygonPoints;
            canvas.Children.Add(line);

            //test();
        }
    }
}
