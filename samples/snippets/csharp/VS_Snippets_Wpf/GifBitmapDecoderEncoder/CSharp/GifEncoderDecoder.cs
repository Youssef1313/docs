﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Security;

[assembly: SecurityTransparent]

namespace SDKSample
{
    public class app : Application
    {
        Window mainWindow;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            CreateAndShowMainWindow();
        }
        private void CreateAndShowMainWindow()
        {

            // Create the application's main window
            mainWindow = new Window();
            mainWindow.Title = "GIF Imaging Sample";
            ScrollViewer mySV = new ScrollViewer();

            //<Snippet4>
            int width = 128;
            int height = width;
            int stride = width / 8;
            byte[] pixels = new byte[height * stride];

            // Define the image palette
            BitmapPalette myPalette = BitmapPalettes.WebPalette;

            // Creates a new empty image with the pre-defined palette

            //<Snippet2>
            BitmapSource image = BitmapSource.Create(
                width,
                height,
                96,
                96,
                PixelFormats.Indexed1,
                myPalette,
                pixels,
                stride);
            //</Snippet2>

            //<Snippet3>
            FileStream stream = new FileStream("new.gif", FileMode.Create);
            GifBitmapEncoder encoder = new GifBitmapEncoder();
            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
            encoder.Frames.Add(BitmapFrame.Create(image));
            encoder.Save(stream);
            //</Snippet3>

            //</Snippet4>

            //<Snippet1>

            // Open a Stream and decode a GIF image
            Stream imageStreamSource = new FileStream("tulipfarm.gif", FileMode.Open, FileAccess.Read, FileShare.Read);
            GifBitmapDecoder decoder = new GifBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];

            // Draw the Image
            Image myImage = new Image();
            myImage.Source = bitmapSource;
            myImage.Stretch = Stretch.None;
            myImage.Margin = new Thickness(20);
            //</Snippet1>

            //<Snippet5>

            // Open a Uri and decode a GIF image
            Uri myUri = new Uri("tulipfarm.gif", UriKind.RelativeOrAbsolute);
            GifBitmapDecoder decoder2 = new GifBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource2 = decoder2.Frames[0];

            // Draw the Image
            Image myImage2 = new Image();
            myImage2.Source = bitmapSource2;
            myImage2.Stretch = Stretch.None;
            myImage2.Margin = new Thickness(20);
            //</Snippet5>

            // Define a StackPanel to host the decoded GIF images
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Orientation = Orientation.Vertical;
            myStackPanel.VerticalAlignment = VerticalAlignment.Stretch;
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;

            // Add the Image and TextBlock to the parent Grid
            myStackPanel.Children.Add(myImage);
            myStackPanel.Children.Add(myImage2);
            myStackPanel.Children.Add(myTextBlock);

            // Add the StackPanel as the Content of the Parent Window Object
            mySV.Content = myStackPanel;
            mainWindow.Content = mySV;
            mainWindow.Show();
        }
    }

    // Define a static entry class
    internal static class EntryClass
    {
        [System.STAThread()]
        private static void Main()
        {
            app app = new app();
            app.Run();
        }
    }
}