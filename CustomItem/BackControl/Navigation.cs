using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;
namespace CustomItem 
{
    

    public interface IInitialize {
        void Initialize(object args);
    }

    public interface IChrome {
        void Navigate(Control previous);
    }

    public static class Navigation {
        public static class GDI32 {
            public const int SRCCOPY = 13369376;
            [DllImport("gdi32.dll")]
            public static extern int BitBlt(
                IntPtr hDC,
                int x,
                int y,
                int nWidth,
                int nHeight,
                IntPtr hSrcDC,
                int xSrc,
                int ySrc,
                int dwRop);
        }
        
        static Image GetControlImage(Control control) {
            using (Graphics graphic = control.CreateGraphics()) {
                Bitmap bitmap = new Bitmap(control.Width, control.Height, graphic);
                try {
                    using (Graphics memory = Graphics.FromImage(bitmap)) {
                        IntPtr dc1 = graphic.GetHdc();
                        try {
                            IntPtr dc2 = memory.GetHdc();
                            GDI32.BitBlt(
                                dc2,
                                0,
                                0,
                                control.ClientRectangle.Width,
                                control.ClientRectangle.Height,
                                dc1, 0, 0,
                                GDI32.SRCCOPY);
                            memory.ReleaseHdc(dc2);
                        } finally {
                            graphic.ReleaseHdc(dc1);
                        }
                    }
                } catch {
                    if (bitmap != null)
                        bitmap.Dispose();
                    throw;
                }
                return bitmap;
            }
        }

        static PictureBox CreateDraftImage(Control parent, Control control) {
            PictureBox box = (PictureBox)Find<PictureBox>(parent);
            while (box != null) {
                box.Visible = false;
                box.Dispose();
                box = (PictureBox)Find<PictureBox>(parent);
            }
            box = new PictureBox();
            try {
                box.Visible = false;
                box.Parent = parent;
                box.BorderStyle = BorderStyle.None;
                box.BringToFront();
                if (control != null) {
                    box.Image = GetControlImage(control);
                }
                box.Dock = DockStyle.Fill;
                box.Cursor = Cursors.WaitCursor;
                box.Visible = true; 
            } catch {
                if (box != null)
                    box.Dispose();
                throw;
            }
            return box;
        }

        public class SwipeTransition : Transition {
            public SwipeTransition(Control target)
                : base(target, target.Parent.ClientRectangle.Right, target.Parent.ClientRectangle.Left, 500) {
            }
            
            //base(target, target.Parent.ClientRectangle.Right, target.Parent.ClientRectangle.Left, 500)
            protected override void OnStart() {
                Control control = this.Target as Control;
                if (control != null) {
                    control.Invoke(new Action(() => {
                        control.Visible = false;
                        control.BringToFront();
                        control.Dock = DockStyle.None;
                        control.Width = control.Parent.ClientRectangle.Width;
                        control.Height = control.Parent.ClientRectangle.Height;
                        control.Top = control.Parent.ClientRectangle.Top;
                        control.Left = control.Parent.ClientRectangle.Right;
                        control.Visible = true;
                    }));
                }
            }
            protected override void OnChanged() {
                Control control = this.Target as Control;
                if (control != null) {
                    control.Invoke(new Action(() => {
                        control.Left = (int)this.Value;
                    }));
                }
            }
            protected override void OnCompleted() {
                Control control = this.Target as Control;
                if (control != null) {
                    control.Invoke(new Action(() => {
                        control.Parent.Text = control.Text;
                        control.Dock = DockStyle.Fill;
                        control.BringToFront();
                        control.Visible = true;
                        Control box = Find<PictureBox>(control.Parent);
                        while (box != null) {
                            box.Visible = false;
                            box.Dispose();
                            box = Find<PictureBox>(control.Parent);
                        }
                    }));
                }
            }
        }

        public class TransitionChild : Transition
        {
            public TransitionChild(Control target)
                : base(target, target.ClientRectangle.Right, target.ClientRectangle.Left, 500)
            {
                
            }
            public TransitionChild(Control target,int __from,int __to,int __duration)
                : base(target, __from, __to, __duration)
            {

            }
            //base(target, target.Parent.ClientRectangle.Right, target.Parent.ClientRectangle.Left, 500)
            protected override void OnStart()
            {
                Control control = this.Target as Control;
                if (control != null)
                {
                    control.Invoke(new Action(() =>
                    {
                        control.Visible = false;
                        control.BringToFront();
                        control.Dock = DockStyle.None;
                        control.Width = control.ClientRectangle.Width;
                        control.Height = control.ClientRectangle.Height;
                        control.Visible = true;
                    }));
                }
            }
            protected override void OnChanged()
            {
                Control control = this.Target as Control;
                if (control != null)
                {
                    control.Invoke(new Action(() =>
                    {
                        control.Left = (int)this.Value;
                    }));
                }
            }
            protected override void OnCompleted()
            {
                Control control = this.Target as Control;
                if (control != null)
                {
                    control.Invoke(new Action(() =>
                    {
                        control.Parent.Text = control.Text;
                        control.Dock = DockStyle.Fill;
                        control.BringToFront();
                        control.Visible = true;
                        Control box = Find<PictureBox>(control.Parent);
                        while (box != null)
                        {
                            box.Visible = false;
                            box.Dispose();
                            box = Find<PictureBox>(control.Parent);
                        }
                    }));
                }
            }
        }

        public static void FillToParent(Control control, bool animate) {
            if (control == null) {
                return;
            }
            if (!control.IsHandleCreated || !animate) {
                try {
                    control.Dock = DockStyle.Fill;
                    control.BringToFront();
                    control.Parent.Text = control.Text;
                    control.Visible = true;
                } finally {
                    Control box = Find<PictureBox>(control.Parent);
                    while (box != null) {
                        box.Dispose();
                        box = Find<PictureBox>(control.Parent); 
                    }
                }
            } else {
                (new SwipeTransition(control)).Start();
            }
        }

        static Type _chrome;
        public static Type Chrome {
            get {
                if (_chrome == null) {
                    return typeof(Layout);
                }
                return _chrome;
            }
            set {
                if (_chrome != null) {
                    throw new InvalidOperationException("Application Chrome is already initialized.");
                }
                _chrome = value;
            }
        }

        static Control Find<T>(Control container) where T : Control { return Find<T>(container, null); }
        static Control Find<T>(Control container, Action<Control> skip) where T : Control {
            Debug.Assert(container != null, "container is null.");
            Control found = null;
            foreach (Control i in container.Controls) {
                if (((Type)i.Tag) == typeof(T) 
                                    || i.GetType() == typeof(T)) {
                    found = i;
                } else {
                    if (skip != null) {
                        skip(i);
                    }
                }
            }
            return found;
        }
        static Control Find(Control container, Predicate<Control> match) {
            Debug.Assert(container != null, "container is null.");
            Control found = null;
            for (int j = container.Controls.Count - 1; j >= 0; j--) {
                if (match(container.Controls[j])) {
                    found = container.Controls[j];
                }
            }
            return found;
        }

        static Control CreateLayout<T>(this Control container, Type chrome) {
            if (chrome == null) {
                chrome = Chrome;
            }
            Control layout = null;
            if (chrome != null && typeof(Control).IsAssignableFrom(chrome)) {
                layout = (Control)Activator.CreateInstance(chrome);
                layout.Visible = false;
                layout.Parent = container;
                layout.Tag = typeof(T);
            }
            return layout;
        }

        public static void GoBack(this Control container) { GoBack(container, null); }
        public static void GoBack(this Control container, object args) {
            Control current = Find(container, k => k.Visible);
            if (current == null) return;
            int index = container.Controls.IndexOf(current) + 1;
            if (index < 0
                    || index >= container.Controls.Count) {
                return;
            }
            Control found = container.Controls[index];
            CreateDraftImage(container, current);
            FillToParent(
                found, 
                true);
        }
        public static void GoHome(this Control container, object args) { GoTo<Control>(container, args); }
        public static void GoHome(this Control container) { GoTo<Control>(container); }
        public static void GoTo(this Control container, Control view, object args) {
            if (view == null || container.Controls.IndexOf(view) < 0)
            {
                GoHome(container, args);
            }
            Control current = Find(container, k => k.Visible);
            if (current != null) {
                CreateDraftImage(container, current);
            }
            FillToParent(
                view,
                true);
        }
        public static void GoTo<T>(this Control container, T view, object args, Type chrome) where T : Control
        {
            if (chrome == null)
            {
                chrome = Chrome;
            }
            if (chrome != null)
            {
                while (true)
                {
                    if (container == null) return;
                    if (container.GetType() != chrome)
                    {
                        break;
                    }
                    container = container.Parent;
                }
            }
            Control current = Find(container, k => k.Visible);
            if (current != null)
            {
                CreateDraftImage(container, current);
            }
            Control found = Find<T>(container, null);
            if (found != null)
            {
                IInitialize init;
                foreach (Control child in found.Controls)
                {
                    init = child as IInitialize;
                    if (init != null)
                    {
                        init.Initialize(args);
                        found.Text = child.Text;
                    }
                }
                init = found as IInitialize;
                if (init != null)
                {
                    init.Initialize(args);
                }
                if (found is IChrome)
                {
                    ((IChrome)found).Navigate(current);
                }
                FillToParent(found, true);
                return;
            }
            Control layout = CreateLayout<T>(container, chrome);
            try
            {
                T module = view ;
                try
                {
                    Form form = module as Form;
                    if (form != null)
                    {
                        form.TopLevel = false;
                        form.FormBorderStyle = FormBorderStyle.None;
                    }
                    if (layout != null)
                    {
                        module.Parent = layout;
                    }
                    else
                    {
                        module.Parent = container;
                    }
                    IInitialize init = module as IInitialize;
                    if (init != null)
                    {
                        init.Initialize(args);
                    }
                    if (layout is IChrome)
                    {
                        ((IChrome)layout).Navigate(current);
                    }
                    FillToParent(module, false);
                }
                catch
                {
                    if (module != null)
                    {
                        module.Dispose();
                    }
                    throw;
                }
                if (layout != null)
                {
                    IntPtr handle = layout.Handle;
                    foreach (Control child in layout.Controls)
                    {
                        handle = child.Handle;
                        foreach (Control child2 in child.Controls)
                        {
                            handle = child2.Handle;
                        }
                    }
                    FillToParent(layout, true);
                }
            }
            catch
            {
                if (layout != null)
                {
                    layout.Dispose();
                }
                throw;
            }
            
        }
        public static void GoTo<T>(this Control container) where T : Control, new() { GoTo<T>(container, null, null); }
        public static void GoTo<T>(this Control container, object args) where T : Control, new() { GoTo<T>(container, args, null); }
        public static void GoTo<T>(this Control container, object args, Type chrome) where T : Control, new() {
            if (chrome == null) {
                chrome = Chrome;
            }
            if (chrome != null) {
                while (true) {
                    if (container == null) return;
                    if (container.GetType() != chrome) {
                        break;
                    }
                    container = container.Parent;
                }
            }
            Control current = Find(container, k => k.Visible);
            if (current != null) {
                CreateDraftImage(container, current);
            }
            Control found = Find<T>(container, null);
            if (found != null) {
                IInitialize init;
                foreach (Control child in found.Controls) {
                    init = child as IInitialize;
                    if (init != null) {
                        init.Initialize(args);
                        found.Text = child.Text;
                    }
                }
                init = found as IInitialize;
                if (init != null) {
                    init.Initialize(args);
                }
                if (found is IChrome) {
                    ((IChrome)found).Navigate(current);
                }
                FillToParent(found, true);
                return;
            }
            Control layout = CreateLayout<T>(container, chrome);
            try {
                T module = new T();
                try {
                    Form form = module as Form;
                    if (form != null) {
                        form.TopLevel = false;
                        form.FormBorderStyle = FormBorderStyle.None;
                    }
                    if (layout != null) {
                        module.Parent = layout;
                    } else {
                        module.Parent = container;
                    }
                    IInitialize init = module as IInitialize;
                    if (init != null) {
                        init.Initialize(args);
                    }
                    if (layout is IChrome) {
                        ((IChrome)layout).Navigate(current);
                    }
                    FillToParent(module, false);
                } catch {
                    if (module != null) {
                        module.Dispose();
                    }
                    throw;
                }
                if (layout != null) {
                    IntPtr handle = layout.Handle;
                    foreach (Control child in layout.Controls) {
                        handle = child.Handle;
                        foreach (Control child2 in child.Controls) {
                            handle = child2.Handle;
                        }
                    }
                    FillToParent(layout, true);
                }
            } catch {
                if (layout != null) {
                    layout.Dispose();
                }
                throw;
            }
        }
    }
}