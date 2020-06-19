using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace NAudio_Plotting{
    /// <summary>
    /// Windows Forms control for painting stereo audio waveforms
    /// </summary>
    public class StereoAudioWavePainter : Panel{

        private Color _foColor;
        private SmoothingMode _gfxQuality = SmoothingMode.Default;
        private CompositingMode _composingMode = CompositingMode.SourceOver;
        private CompositingQuality _composingQuality = CompositingQuality.Default;
        private InterpolationMode _interpolMode = InterpolationMode.Default;
        private PixelOffsetMode _pixelMode = PixelOffsetMode.Default;

        private Plotmode _plMode;
        private int _maxSamples;

        private int _insertPos;
        private List<float> _leftSamples = new List<float>();

        private List<float> _rightSamples = new List<float>();

        private PinchMode _pinch = PinchMode.None;

        private LinearGradientBrush _br;
        private NAudio.Gui.Fader fader1;
        private int _x;

        public StereoAudioWavePainter()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            OnForeColorChanged(EventArgs.Empty);
            OnResize(EventArgs.Empty);
        }

        /// <summary>
        /// On ForeColor Changed
        /// </summary>
        /// <param name="e"></param>
        protected override sealed void OnForeColorChanged(EventArgs e)
        {
            _foColor = ForeColor;
            base.OnForeColorChanged(e);
        }

        /// <summary>
        /// On Resize
        /// </summary>
        protected override sealed void OnResize(EventArgs e)
        {
            _maxSamples = Width;
            _leftSamples = new List<float>(_maxSamples);
            _rightSamples = new List<float>(_maxSamples);
            _insertPos = 0;
            base.OnResize(e);
        }

        /// <summary>
        /// Add Left and Right channel values
        /// </summary>
        /// <param name="leftSample"></param>
        /// <param name="rightSample"></param>
        public void AddLeftRight(float leftSample, float rightSample)
        {
            if (_maxSamples == 0){
                // sometimes when you minimise, max samples can be set to 0
                return;
            }

            if (_leftSamples.Count <= _maxSamples)
            {
                if (_plMode == Plotmode.LeftUpRightDown)
                {
                    _leftSamples.Add(Math.Abs(leftSample));
                }
                else if (_plMode == Plotmode.PlusMinus | _plMode == Plotmode.Dual)
                {
                    _leftSamples.Add(leftSample);
                }
            }
            else if (_insertPos < _maxSamples)
            {
                if (_plMode == Plotmode.LeftUpRightDown)
                {
                    _leftSamples[_insertPos] = Math.Abs(leftSample);
                }
                else if (_plMode == Plotmode.PlusMinus | _plMode == Plotmode.Dual)
                {
                    _leftSamples[_insertPos] = leftSample;
                }
            }

            if (_rightSamples.Count <= _maxSamples)
            {
                if (_plMode == Plotmode.LeftUpRightDown)
                {
                    _rightSamples.Add(Math.Abs(rightSample));
                }
                else if (_plMode == Plotmode.PlusMinus | _plMode == Plotmode.Dual)
                {
                    _rightSamples.Add(rightSample);
                }
            }
            else if (_insertPos < _maxSamples)
            {
                if (_plMode == Plotmode.LeftUpRightDown)
                {
                    _rightSamples[_insertPos] = Math.Abs(rightSample);
                }
                else if (_plMode == Plotmode.PlusMinus | _plMode == Plotmode.Dual)
                {
                    _rightSamples[_insertPos] = rightSample;
                }
            }

            _insertPos += 1;
            _insertPos = _insertPos % _maxSamples;

            Invalidate();
        }

        /// <summary>
        /// On Paint
        /// </summary>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            //Apply gfx credentials.
            var with1 = pe.Graphics;
            with1.SmoothingMode = _gfxQuality;
            with1.CompositingMode = _composingMode;
            with1.CompositingQuality = _composingQuality;
            with1.InterpolationMode = _interpolMode;
            with1.PixelOffsetMode = _pixelMode;

            float middle = (float)(Math.Floor((double)(Height / 2)) - 1);

            switch (_plMode)
            {
                case Plotmode.LeftUpRightDown:
                    if (DrawMode == DisplayMode.Line && _gfxQuality == SmoothingMode.HighSpeed)
                    {
                        if (ShowMidLine) pe.Graphics.DrawLine(new Pen(MiddleLineColor), 0, middle, Width, middle);

                        for (_x = 0; _x <= Width - 1; _x++)
                        {
                            float leftLineHeight = middle * GetLeftSample(_x - Width + _insertPos);
                            float rightLineHeight = middle * GetRightSample(_x - Width + _insertPos);
                            ApplyPinch(ref leftLineHeight, ref _x);
                            ApplyPinch(ref rightLineHeight, ref _x);
                            pe.Graphics.DrawLine(new Pen(MiddleLineColor), _x, middle, _x, middle - leftLineHeight);
                            pe.Graphics.DrawLine(new Pen(MiddleLineColor), _x, middle, _x, middle + rightLineHeight);
                        }
                    }
                    else if (DrawMode == DisplayMode.Line && (_gfxQuality == SmoothingMode.HighQuality || _gfxQuality == SmoothingMode.AntiAlias))
                    {
                        GraphicsPath paLeft = new GraphicsPath();
                        GraphicsPath paRight = new GraphicsPath();

                        if (ShowMidLine) pe.Graphics.DrawLine(new Pen(MiddleLineColor), 0, middle, Width, middle);

                        paLeft.AddLine(0, middle, 0, middle);
                        paRight.AddLine(0, middle, 0, middle);

                        for (_x = 0; _x <= Width - 1; _x++)
                        {
                            float leftLineHeight = middle * GetLeftSample(_x - Width + _insertPos);
                            float rightLineHeight = middle * GetRightSample(_x - Width + _insertPos);
                            ApplyPinch(ref leftLineHeight, ref _x);
                            ApplyPinch(ref rightLineHeight, ref _x);
                            paLeft.AddLine(_x, middle - leftLineHeight, _x, middle - leftLineHeight);
                            paRight.AddLine(_x, middle + rightLineHeight, _x, middle + rightLineHeight);
                        }

                        paLeft.AddLine(Width - 1, middle, Width - 1, middle);
                        paRight.AddLine(Width - 1, middle, Width - 1, middle);
                        paLeft.CloseFigure();
                        paRight.CloseFigure();
                        paLeft.AddPath(paRight, false);

                        //pe.Graphics.DrawPath(New Pen(foColor), paLeft)

                        if (Gradient)
                        {
                            using (_br = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), GradientColor, _foColor, LinearGradientMode.Vertical))
                            {
                                ApplyBlend(ref _br);
                                pe.Graphics.FillPath(_br, paLeft);
                            }
                        }
                        else
                        {
                            pe.Graphics.FillPath(new SolidBrush(_foColor), paLeft);
                        }

                        paLeft.Dispose();
                        paRight.Dispose();
                    }
                    else if (DrawMode == DisplayMode.Point)
                    {
                        GraphicsPath paLeft = new GraphicsPath();
                        GraphicsPath paRight = new GraphicsPath();

                        if (ShowMidLine) { paLeft.AddLine(0, middle, 0, middle); paRight.AddLine(0, middle, 0, middle); }

                        for (_x = 0; _x <= Width - 1; _x++)
                        {
                            float leftLineHeight = middle * GetLeftSample(_x - Width + _insertPos);
                            float rightLineHeight = middle * GetRightSample(_x - Width + _insertPos);
                            ApplyPinch(ref leftLineHeight, ref _x);
                            ApplyPinch(ref rightLineHeight, ref _x);
                            paLeft.AddLine(_x, middle - leftLineHeight, _x, middle - leftLineHeight);
                            paRight.AddLine(_x, middle + rightLineHeight, _x, middle + rightLineHeight);
                        }

                        if (ShowMidLine)
                        {
                            paLeft.AddLine(Width - 1, middle, Width - 1, middle);
                            paRight.AddLine(Width - 1, middle, Width - 1, middle);
                            paLeft.CloseFigure();
                            paRight.CloseFigure();
                        }

                        pe.Graphics.DrawPath(new Pen(MiddleLineColor), paLeft);
                        pe.Graphics.DrawPath(new Pen(MiddleLineColor), paRight);
                        paLeft.Dispose();
                        paRight.Dispose();
                    }
                    break;
                case Plotmode.PlusMinus:
                    if (ShowMidLine) pe.Graphics.DrawLine(new Pen(MiddleLineColor), 0, middle, Width, middle);

                    using (GraphicsPath path = new GraphicsPath())
                    {
                        for (_x = 0; _x <= Width - 1; _x++)
                        {
                            float mixed = (GetLeftSample(_x - Width + _insertPos) + GetRightSample(_x - Width + _insertPos)) / 2;
                            ApplyPinch(ref mixed, ref _x);

                            if (DrawMode == DisplayMode.Line)
                            {
                                path.AddLines(new[] {
                                    new Point(_x, (int) middle),
                                    new Point(_x, Convert.ToInt32(middle - middle * mixed))
                                });
                            }
                            else if (DrawMode == DisplayMode.Point)
                            {
                                path.AddLines(new[] {
                                    new Point(_x, Convert.ToInt32(middle - middle * mixed)),
                                    new Point(_x, Convert.ToInt32(middle - middle * mixed))
                                });
                            }
                        }

                        if (DrawMode == DisplayMode.Line)
                        {
                            if (Gradient)
                            {
                                using (_br = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), GradientColor, _foColor, LinearGradientMode.Vertical))
                                {
                                    ApplyBlend(ref _br);
                                    pe.Graphics.DrawPath(new Pen(_br), path);
                                }
                            }
                            else
                            {
                                pe.Graphics.DrawPath(new Pen(_foColor), path);
                            }
                        }
                        else if (DrawMode == DisplayMode.Point)
                        {
                            pe.Graphics.DrawPath(new Pen(_foColor), path);
                        }
                    }
                    break;
                case Plotmode.Dual:

                    //Draw seperator line.
                    if (ShowMidLine) pe.Graphics.DrawLine(new Pen(MiddleLineColor), 0, middle, Width, middle);

                    //Left channel.
                    using (GraphicsPath leftpath = new GraphicsPath())
                    {
                        for (_x = 0; _x <= Width - 1; _x++)
                        {
                            float mixed = GetLeftSample(_x - Width + _insertPos);
                            ApplyPinch(ref mixed, ref _x);

                            if (DrawMode == DisplayMode.Line)
                            {
                                leftpath.AddLines(new[] {
                                    new Point(_x, Convert.ToInt32(middle / 2)),
                                    new Point(_x, Convert.ToInt32((middle / 2) - (middle / 2 * mixed)))
                                });
                            }
                            else if (DrawMode == DisplayMode.Point)
                            {
                                leftpath.AddLines(new[] {
                                    new Point(_x, Convert.ToInt32(middle / 2 - (middle / 2 * mixed))),
                                    new Point(_x, Convert.ToInt32(middle / 2 - (middle / 2 * mixed)))
                                });
                            }
                        }

                        if (DrawMode == DisplayMode.Line)
                        {
                            if (Gradient)
                            {
                                using (_br = new LinearGradientBrush(new Rectangle(0, 0, Width, Convert.ToInt32(middle)), GradientColor, _foColor, LinearGradientMode.Vertical))
                                {
                                    ApplyBlend(ref _br);
                                    pe.Graphics.DrawPath(new Pen(_br), leftpath);
                                }
                            }
                            else
                            {
                                pe.Graphics.DrawPath(new Pen(_foColor), leftpath);
                            }
                        }
                        else if (DrawMode == DisplayMode.Point)
                        {
                            pe.Graphics.DrawPath(new Pen(_foColor), leftpath);
                        }
                    }

                    using (GraphicsPath rightpath = new GraphicsPath())
                    {
                        for (_x = 0; _x <= Width - 1; _x++)
                        {
                            float mixed = GetRightSample(_x - Width + _insertPos);
                            ApplyPinch(ref mixed, ref _x);

                            if (DrawMode == DisplayMode.Line)
                            {
                                rightpath.AddLines(new[] {
                                    new Point(_x, Convert.ToInt32(Height * 3 / 4)),
                                    new Point(_x, Convert.ToInt32((Height * 3 / 4) - (middle / 2 * mixed)))
                                });
                            }
                            else if (DrawMode == DisplayMode.Point)
                            {
                                rightpath.AddLines(new[] {
                                    new Point(_x, Convert.ToInt32(Height * 3 / 4 - (middle / 2 * mixed))),
                                    new Point(_x, Convert.ToInt32(Height * 3 / 4 - (middle / 2 * mixed)))
                                });
                            }
                        }

                        if (DrawMode == DisplayMode.Line)
                        {
                            if (Gradient)
                            {
                                using (_br = new LinearGradientBrush(new Rectangle(0, 0, Width, Convert.ToInt32(middle)), GradientColor, _foColor, LinearGradientMode.Vertical))
                                {
                                    ApplyBlend(ref _br);
                                    pe.Graphics.DrawPath(new Pen(_br), rightpath);
                                }
                            }
                            else
                            {
                                pe.Graphics.DrawPath(new Pen(_foColor), rightpath);
                            }
                        }
                        else if (DrawMode == DisplayMode.Point)
                        {
                            pe.Graphics.DrawPath(new Pen(_foColor), rightpath);
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Applies the x position pinch either to raw or mixed samples.
        /// </summary>
        /// <param name="receiveSample">The recieve sample.</param>
        /// <param name="xx">The x pos.</param>
        private void ApplyPinch(ref float receiveSample, ref int xx)
        {
            switch (_pinch)
            {
                case PinchMode.None:
                    // ??
                    break;
                case PinchMode.OutsideSine:
                    receiveSample *= (float)(Math.Sin(xx / Width * Math.PI));
                    break;
                case PinchMode.InsideCosine:
                    receiveSample *= (float)(Math.Cos(xx / Width * Math.PI));
                    break;
                case PinchMode.InverseMdct:
                    receiveSample *= (float)(Math.Sin(0.5 * Math.PI * (Math.Pow(Math.Sin((xx + 0.5) / Width * Math.PI), 2))));
                    break;
            }
        }

        /// <summary>
        /// Applies a blend effect to a LinearGradientBrush.
        /// </summary>
        /// <param name="brush">The LinearGradientBrush that will recieve the blend.</param>
        private static void ApplyBlend(ref LinearGradientBrush brush)
        {
            float[] relativeIntensities = {
                0f,
                1f,
                0f
            };
            float[] relativePositions = {
                0f,
                0.5f,
                1f
            };

            Blend blend = new Blend { Factors = relativeIntensities, Positions = relativePositions };
            brush.Blend = blend;
        }

        private float GetLeftSample(int index)
        {
            if (index < 0)
            {
                index += _maxSamples;
            }
            if (index >= 0 & index < _leftSamples.Count)
            {
                return _leftSamples[index];
            }
            return 0;
        }

        private float GetRightSample(int index)
        {
            if (index < 0)
            {
                index += _maxSamples;
            }

            if (index >= 0 & index < _rightSamples.Count)
            {
                return _rightSamples[index];
            }

            return 0;
        }

        /// <summary>
        /// Gets or sets the quality of all drawn graphics.
        /// </summary>
        [Description("Gets or sets the quality of all drawn graphics.")]
        public SmoothingMode QualityMode
        {
            get { return _gfxQuality; }
            set { _gfxQuality = value; }
        }

        /// <summary>
        /// Gets or sets the compositing mode of all drawn graphics.
        /// </summary>
        [Description("Gets or sets the compositing mode of all drawn graphics.")]
        public CompositingMode CompositingMode
        {
            get { return _composingMode; }
            set { _composingMode = value; }
        }

        /// <summary>
        /// Gets or sets the compositing quality of all drawn graphics.
        /// </summary>
        [Description("Gets or sets the compositing quality of all drawn graphics.")]
        public CompositingQuality CompositingQuality
        {
            get { return _composingQuality; }
            set { _composingQuality = value; }
        }

        /// <summary>
        /// Gets or sets the interpolation mode of all drawn graphics.
        /// </summary>
        [Description("Gets or sets the interpolation mode of all drawn graphics.")]
        public InterpolationMode InterpolationMode
        {
            get { return _interpolMode; }
            set { _interpolMode = value; }
        }


        /// <summary>
        /// Gets or sets the pixel offset mode of all drawn graphics.
        /// </summary>
        [Description("Gets or sets the pixel offset mode of all drawn graphics.")]
        public PixelOffsetMode PixelOffsetMode
        {
            get { return _pixelMode; }
            set { _pixelMode = value; }
        }

        /// <summary>
        /// Enumerates the display modes
        /// </summary>
        public enum DisplayMode
        {
            Line = 0,
            Point = 1
        }

        /// <summary>
        /// Enumerates the pinch modes
        /// </summary>
        public enum PinchMode
        {
            None = 0,
            OutsideSine = 1,
            InsideCosine = 2,
            InverseMdct = 3
        }

        /// <summary>
        /// Enumerates the plotting modes
        /// </summary>
        public enum Plotmode
        {
            PlusMinus = 0,
            LeftUpRightDown = 1,
            Dual = 2
        }

        /// <summary>
        /// Gets or sets the plotting method.
        /// </summary>
        [Description("Gets or sets the plotting method.")]
        public Plotmode Plot
        {
            get { return _plMode; }
            set
            {
                _plMode = value;
                //Reset.
                _leftSamples.Clear();
                _rightSamples.Clear();
                _insertPos = 0;
            }
        }

        /// <summary>
        /// Gets or sets the display method.
        /// </summary>
        [Description("Gets or sets the display method.")]
        public DisplayMode DrawMode { get; set; }

        /// <summary>
        /// Gets or sets if the display uses gradient colors.
        /// </summary>
        [Description("Gets or sets if the display uses gradient colors.")]
        public bool Gradient { get; set; }

        /// <summary>
        /// Gets or sets the gradient color, that is used in Line Mode.
        /// </summary>
        [Description("Gets or sets the gradient color, that is used in Line Mode.")]
        public Color GradientColor { get; set; }

        /// <summary>
        /// Gets or sets if the middle line is displayed.
        /// </summary>
        [Description("Gets or sets if the middle line is displayed (Line HQ Mode must show).")]
        public bool ShowMidLine { get; set; }

        [Description("Gets or sets the fore color of the middle line if this is being drawn.")]
        public Color MiddleLineColor { get; set; }

        /// <summary>
        /// Gets or sets the way pinch is applied to the waveform.
        /// </summary>
        [Description("Gets or sets the way pinch is applied to the waveform.")]
        public PinchMode Pinch
        {
            get { return _pinch; }
            set { _pinch = value; }
        }

        private void InitializeComponent()
        {
            this.fader1 = new NAudio.Gui.Fader();
            this.SuspendLayout();
            // 
            // fader1
            // 
            this.fader1.Location = new System.Drawing.Point(0, 0);
            this.fader1.Maximum = 0;
            this.fader1.Minimum = 0;
            this.fader1.Name = "fader1";
            this.fader1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.fader1.Size = new System.Drawing.Size(0, 0);
            this.fader1.TabIndex = 0;
            this.fader1.Text = "fader1";
            this.fader1.Value = 0;
            this.ResumeLayout(false);

        }
    }
}