using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackDropCreate
{
    public partial class Form1 : Form
    {
        private static readonly byte[,] NEXT_PALETTE = new byte[256, 3] {
/* 000 */   {0, 0, 0}, {0, 0, 109}, {0, 0, 182}, {0, 0, 255}, {0, 36, 0}, {0, 36, 109}, {0, 36, 182}, {0, 36, 255},
/* 008 */   {0, 73, 0}, {0, 73, 109}, {0, 73, 182}, {0, 73, 255}, {0, 109, 0}, {0, 109, 109}, {0, 109, 182}, {0, 109, 255},
/* 016 */   {0, 146, 0}, {0, 146, 109}, {0, 146, 182}, {0, 146, 255}, {0, 182, 0}, {0, 182, 109},{0, 182, 182}, {0, 182, 255},
/* 024 */   {0, 219, 0}, {0, 219, 109}, {0, 219, 182}, {0, 219, 255}, {0, 255, 0}, {0, 255, 109}, {0, 255, 182}, {0, 255, 255},
/* 032 */   {36, 0, 0}, {36, 0, 109}, {36, 0, 182}, {36, 0, 255}, {36, 36, 0}, {36, 36, 109}, {36, 36, 182}, {36, 36, 255},
/* 040 */   {36, 73, 0}, {36, 73, 109}, {36, 73, 182}, {36, 73, 255}, {36, 109, 0}, {36, 109, 109}, {36, 109, 182}, {36, 109, 255},
/* 048 */   {36, 146, 0}, {36, 146, 109}, {36, 146, 182}, {36, 146, 255}, {36, 182, 0}, {36, 182, 109}, {36, 182, 182}, {36, 182, 255},
/* 056 */   {36, 219, 0}, {36, 219, 109}, {36, 219, 182}, {36, 219, 255}, {36, 255, 0}, {36, 255, 109}, {36, 255, 182}, {36, 255, 255},
/* 064 */   {73, 0, 0}, {73, 0, 109}, {73, 0, 182}, {73, 0, 255}, {73, 36, 0}, {73, 36, 109}, {73, 36, 182}, {73, 36, 255},
/* 072 */   {73, 73, 0}, {73, 73, 109}, {73, 73, 182}, {73, 73, 255}, {73, 109, 0}, {73, 109, 109}, {73, 109, 182},{73, 109, 255},
/* 080 */   {73, 146, 0}, {73, 146, 109}, {73, 146, 182}, {73, 146, 255}, {73, 182, 0}, {73, 182, 109}, {73, 182, 182}, {73, 182, 255},
/* 088 */   {73, 219, 0}, {73, 219, 109}, {73, 219, 182}, {73, 219, 255}, {73, 255, 0}, {73, 255, 109}, {73, 255, 182}, {73, 255, 255},
/* 196 */   {109, 0, 0}, {109, 0, 109}, {109, 0, 182}, {109, 0, 255}, {109, 36, 0}, {109, 36, 109}, {109, 36, 182}, {109, 36, 255},
/* 104 */   {109, 73, 0}, {109, 73, 109}, {109, 73, 182}, {109, 73, 255}, {109, 109, 0}, {109, 109, 109}, {109, 109, 182}, {109, 109, 255},
/* 112 */   {109, 146, 0}, {109, 146, 109}, {109, 146, 182}, {109, 146, 255}, {109, 182, 0}, {109, 182, 109}, {109, 182, 182}, {109, 182, 255},
/* 120 */   {109, 219, 0}, {109, 219, 109}, {109, 219, 182}, {109, 219, 255}, {109, 255, 0}, {109, 255, 109}, {109, 255, 182}, {109, 255, 255},
/* 128 */   {146, 0, 0}, {146, 0, 109}, {146, 0, 182}, {146, 0, 255}, {146, 36, 0}, {146, 36, 109}, {146, 36, 182}, {146, 36, 255},
/* 136 */   {146, 73, 0}, {146, 73, 109}, {146, 73, 182}, {146, 73, 255}, {146, 109, 0}, {146, 109, 109}, {146, 109, 182}, {146, 109, 255},
/* 144 */   {146, 146, 0}, {146, 146, 109}, {146, 146, 182}, {146, 146, 255}, {146, 182, 0}, {146, 182, 109}, {146, 182, 182}, {146, 182, 255},
/* 152 */   {146, 219, 0}, {146, 219, 109}, {146, 219, 182}, {146, 219, 255}, {146, 255, 0}, {146, 255, 109}, {146, 255, 182}, {146, 255, 255},
/* 160 */   {182, 0, 0}, {182, 0, 109}, {182, 0, 182}, {182, 0, 255}, {182, 36, 0}, {182, 36, 109}, {182, 36, 182}, {182, 36, 255},
/* 168 */   {182, 73, 0}, {182, 73, 109}, {182, 73, 182}, {182, 73, 255}, {182, 109, 0}, {182, 109, 109}, {182, 109, 182}, {182, 109, 255},
/* 176 */   {182, 146, 0}, {182, 146, 109}, {182, 146, 182}, {182, 146, 255}, {182, 182, 0}, {182, 182, 109}, {182, 182, 182}, {182, 182, 255},
/* 184 */   {182, 219, 0}, {182, 219, 109}, {182, 219, 182}, {182, 219, 255}, {182, 255, 0}, {182, 255, 109}, {182, 255, 182}, {182, 255, 255},
/* 192 */   {219, 0, 0}, {219, 0, 109}, {219, 0, 182}, {219, 0, 255}, {219, 36, 0}, {219, 36, 109}, {219, 36, 182}, {219, 36, 255},
/* 200 */   {219, 73, 0}, {219, 73, 109}, {219, 73, 182}, {219, 73, 255}, {219, 109, 0}, {219, 109, 109}, {219, 109, 182}, {219, 109, 255},
/* 208 */   {219, 146, 0}, {219, 146, 109}, {219, 146, 182}, {219, 146, 255}, {219, 182, 0}, {219, 182, 109}, {219, 182, 182}, {219, 182, 255},
/* 216 */   {219, 219, 0}, {219, 219, 109}, {219, 219, 182}, {219, 219, 255}, {219, 255, 0}, {219, 255, 109}, {219, 255, 182}, {219, 255, 255},
/* 224 */   {255, 0, 0}, {255, 0, 109}, {255, 0, 182}, {255, 0, 255}, {255, 36, 0}, {255, 36, 109}, {255, 36, 182}, {255, 36, 255},
/* 232 */   {255, 73, 0}, {255, 73, 109}, {255, 73, 182}, {255, 73, 255}, {255, 109, 0}, {255, 109, 109}, {255, 109, 182}, {255, 109, 255},
/* 240 */   {255, 146, 0}, {255, 146, 109}, {255, 146, 182}, {255, 146, 255}, {255, 182, 0}, {255, 182, 109}, {255, 182, 182}, {255, 182, 255},
/* 248 */   {255, 219, 0}, {255, 219, 109}, {255, 219, 182}, {255, 219, 255}, {255, 255, 0}, {255, 255, 109}, {255, 255, 182}, {255, 255, 255}
        };
        private static readonly byte[,] ORIGINAL_PALETTE = new byte[16, 3] {
/* 000 */   {0, 0, 0}, {1, 0, 206}, {207, 1, 0}, {207, 1, 206}, {0, 207, 21}, {1, 207, 207}, {207, 207, 21}, {207, 207, 207},
/* 008 */   {0, 0, 0}, {2, 0, 253}, {255, 2, 1}, {255, 2, 253}, {0, 255, 28}, {2, 255, 255}, {255, 255, 29}, {255, 255, 255}
        };
        private int[] tempColorMapCache = Enumerable.Repeat(-1, 16777216).ToArray();
        private byte[] colorMapCache = null;

        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap createFullSizeKnLoaderBackdrop(double width, double height, Image image)
        {
            Console.WriteLine(height);
            Console.WriteLine(image.Width);
            Console.WriteLine(image.Height);
            Bitmap resultBitmap;
            if (height == 0)
                resultBitmap = new Bitmap((int)(2 * width), (int)(192 * (width / 128)), PixelFormat.Format24bppRgb);
            else
                resultBitmap = new Bitmap((int)(256 * (height / 192)), (int)height, PixelFormat.Format24bppRgb);
            Console.WriteLine(resultBitmap.Width);
            Console.WriteLine(resultBitmap.Height);
            float halfWidth = resultBitmap.Width / 2;
            Graphics graphics = Graphics.FromImage(resultBitmap);
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Console.WriteLine();
            graphics.DrawImage(image, new Rectangle((int)(halfWidth + (halfWidth - image.Width) / 2), (int)((resultBitmap.Height - image.Height) / 2), image.Width, image.Height));
            graphics.Dispose();
            return resultBitmap;
        }

        private Bitmap resizeBitmap(Bitmap bitmap, int width, int height)
        {
            Bitmap resultBitmap = new Bitmap(width, height, bitmap.PixelFormat);
            Graphics graphics = Graphics.FromImage(resultBitmap);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(bitmap, 0, 0, width, height);
            graphics.Dispose();
            return resultBitmap;
        }

        private Bitmap convertToSpectrumNextColors(Bitmap bitmap)
        {
            // Create bitmap with Spectrum Next palette

            Bitmap resultBitmap = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format8bppIndexed);
            ColorPalette palette = resultBitmap.Palette;
            for (int i = 0; i < NEXT_PALETTE.GetLength(0); i++)
                palette.Entries[i] = Color.FromArgb(255, NEXT_PALETTE[i, 0], NEXT_PALETTE[i, 1], NEXT_PALETTE[i, 2]);
            resultBitmap.Palette = palette;

            // Map 24bbp bitmap pixels to 8bit indexed bitmap 

            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
            BitmapData outputData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.WriteOnly, resultBitmap.PixelFormat);
            int bmpStride = bmpData.Stride;
            int outputStride = outputData.Stride;
            unsafe
            {
                byte* bmpPtr = (byte*)bmpData.Scan0.ToPointer();
                byte* outputPtr = (byte*)outputData.Scan0.ToPointer();

                for (int row = 0; row < bitmap.Height; row++)
                    for (int inputColumn = 0, outputColumn = 0; outputColumn < bitmap.Width; inputColumn += 3, ++outputColumn)
                    {
                        int blue = bmpPtr[row * bmpStride + inputColumn];
                        int green = bmpPtr[row * bmpStride + inputColumn + 1];
                        int red = bmpPtr[row * bmpStride + inputColumn + 2];

                        int colorMapIndex = 0;
                        int key = red + (256 * green) + (65536 * blue);
                        if (this.colorMapCache != null)
                            colorMapIndex = this.colorMapCache[key];
                        else if (this.tempColorMapCache[key] == -1)
                        {
                            double shortestDistance = -1;
                            for (int i = 0; i < NEXT_PALETTE.GetLength(0); i++)
                            {
                                int testRed = NEXT_PALETTE[i, 0];
                                int testGreen = NEXT_PALETTE[i, 1];
                                int testBlue = NEXT_PALETTE[i, 2];

                                double distance = Math.Pow((red - testRed) * 0.30, 2) + Math.Pow((green - testGreen) * 0.59, 2) + Math.Pow((blue - testBlue) * 0.11, 2);
                                if ((shortestDistance == -1) || (distance < shortestDistance))
                                {
                                    shortestDistance = distance;
                                    colorMapIndex = i;
                                }
                            }
                            this.tempColorMapCache[key] = colorMapIndex;
                        }
                        else
                            colorMapIndex = this.tempColorMapCache[key];

                        outputPtr[row * outputStride + outputColumn] = (byte)colorMapIndex;
                    }
            }
            bitmap.UnlockBits(bmpData);
            resultBitmap.UnlockBits(outputData);
            return resultBitmap;
        }

        private void createColorMapCache()
        {
            byte[] colorMapCache = new byte[16777216];
            for (int blue = 0; blue < 256; blue++)
            {
                Console.WriteLine(blue);
                for (int green = 0; green < 256; green++)
                {
                    for (int red = 0; red < 256; red++)
                    {
                        int key = red + (256 * green) + (65536 * blue);
                        byte nearestIndex = 0;
                        double shortestDistance = -1;
                        for (int i = 0; i < NEXT_PALETTE.GetLength(0); i++)
                        {
                            int testRed = NEXT_PALETTE[i, 0];
                            int testGreen = NEXT_PALETTE[i, 1];
                            int testBlue = NEXT_PALETTE[i, 2];

                            double distance = Math.Pow((red - testRed) * 0.30, 2) + Math.Pow((green - testGreen) * 0.59, 2) + Math.Pow((blue - testBlue) * 0.11, 2);
                            if ((shortestDistance == -1) || (distance < shortestDistance))
                            {
                                shortestDistance = distance;
                                nearestIndex = (byte)i;
                            }
                        }
                        colorMapCache[key] = nearestIndex;
                    }
                }
            }
            File.WriteAllBytes("ColorMapCache.bin", colorMapCache);
        }

        private void CreateSpectrumNextKnLoaderBackdop(double width, double height, Image image, String file)
        {
            Bitmap fullSizeKnLoaderBackdrop = this.createFullSizeKnLoaderBackdrop(width, height, image);
            Bitmap resizedBitmap = this.resizeBitmap(fullSizeKnLoaderBackdrop, 256, 192);
            Bitmap spectrumNextColorBitmap = this.convertToSpectrumNextColors(resizedBitmap);

            //fullSizeKnLoaderBackdrop.Save("Output\\" + Path.GetFileNameWithoutExtension(file) + " Full.bmp", ImageFormat.Bmp);
            //resizedBitmap.Save("Output\\" + Path.GetFileNameWithoutExtension(file) + " Size.bmp", ImageFormat.Bmp);
            spectrumNextColorBitmap.Save("Output\\" + Path.GetFileNameWithoutExtension(file) + " Back.bmp", ImageFormat.Bmp);
        }

        private Bitmap ConvertScrToBmp(String file)
        {
            byte[] videoRam = File.ReadAllBytes(file);
            Bitmap resultBitmap = new Bitmap(256, 192, PixelFormat.Format24bppRgb);
            BitmapData outputData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.WriteOnly, resultBitmap.PixelFormat);
            unsafe
            {
                byte* outputPtr = (byte*)outputData.Scan0.ToPointer();
                for (int charY = 0; charY < 24; charY++)
                {
                    for (int charX = 0; charX < 32; charX++)
                    {
                        uint charAttr = videoRam[6144 + charY * 32 + charX];
                        uint bright = (charAttr & 64) >> 3;
                        uint frontColor = (charAttr & 7) + bright;
                        uint backColor = ((charAttr >> 3) & 7) + bright;

                        int videoRamSection = charY / 8;
                        int videoRamLine = charY % 8;
                        for (int charPixelLine = 0; charPixelLine < 8; charPixelLine++)
                        {
                            int row = charY * 8 + charPixelLine;
                            int videoRamPosition = videoRamSection * 2048 + videoRamLine * 32 + charPixelLine * 256 + charX;
                            uint videoRamByte = videoRam[videoRamPosition];
                            for (int charPixel = 0; charPixel < 8; charPixel++)
                            {
                                uint pixelColor;
                                if ((videoRamByte & 128) != 0) pixelColor = frontColor; else pixelColor = backColor;
                                byte red = ORIGINAL_PALETTE[pixelColor, 0];
                                byte green = ORIGINAL_PALETTE[pixelColor, 1];
                                byte blue = ORIGINAL_PALETTE[pixelColor, 2];

                                int outputColumn = (charX * 8 + charPixel) * 3;
                                outputPtr[row * outputData.Stride + outputColumn] = blue;
                                outputPtr[row * outputData.Stride + outputColumn + 1] = green;
                                outputPtr[row * outputData.Stride + outputColumn + 2] = red;
                                videoRamByte = videoRamByte << 1;
                            }
                        }
                    }
                }
            }
            resultBitmap.UnlockBits(outputData);
            return resultBitmap;
        }

        private void ProcessFile(String file)
        {
            Image image = Bitmap.FromFile(file);
            if (Convert.ToDouble(image.Height) / image.Width >= 192d / 128)
                this.CreateSpectrumNextKnLoaderBackdop(0, image.Height, image, file);
            else
                this.CreateSpectrumNextKnLoaderBackdop(image.Width, 0, image, file);
        }

        private void ScanDir(String dir)
        {
            Directory.CreateDirectory("Output");
            String[] files = Directory.GetFiles(dir, "*.jpg");
            foreach (String file in files)
                this.ProcessFile(file);
            files = Directory.GetFiles(dir, "*.bmp");
            foreach (String file in files)
                this.ProcessFile(file);
            files = Directory.GetFiles(dir, "*.png");
            foreach (String file in files)
                this.ProcessFile(file);
            files = Directory.GetFiles(dir, "*.scr");
            foreach (String file in files)
            {
                Bitmap scrBitmap = ConvertScrToBmp(file);
                this.CreateSpectrumNextKnLoaderBackdop(256, 0, scrBitmap, file);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\ColorMapCache.bin"))
                this.colorMapCache = File.ReadAllBytes(Path.GetDirectoryName(Application.ExecutablePath) + "\\ColorMapCache.bin");
            this.ScanDir(Path.GetDirectoryName(Application.ExecutablePath));
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.createColorMapCache();
        }
    }
}
