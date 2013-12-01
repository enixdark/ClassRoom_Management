using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
namespace CustomItem {
    

    public interface ITransitionTarget {
        void OnStart(Transition transition);
        void OnCompleted(Transition transition);
        void OnChanged(Transition transition);
    }

    public class TransitionBase {
        public TransitionBase(object target, Double from, Double to) : this(target, from, to, 500) { }
        public TransitionBase(object target, Double from, Double to, int duration) {
            if (duration < 0) {
                throw new ArgumentOutOfRangeException("duration");
            }
            _target = target;
            _from = from;
            _to = to;
            _value = Double.NaN;
            _duration = duration;
        }
        object _target;
        /// <summary>
        /// Transition target.
        /// </summary>
        public object Target {
            get {
                return _target;
            }
        }
        int _duration;
        /// <summary>
        /// Transition duration in milliseconds.
        /// </summary>
        public int Duration {
            get {
                return _duration;
            }
        }
        protected Double _from;
        /// <summary>
        /// From value.
        /// </summary>
        public Double From {
            get {
                return _from;
            }
        }
        protected Double _to;
        /// <summary>
        /// To value.
        /// </summary>
        public Double To {
            get {
                return _to;
            }
        }
        protected Double _value;
        /// <summary>
        /// Current value.
        /// </summary>
        public Double Value {
            get {
                return _value;
            }
        }
        protected Stopwatch _elapsedMilliseconds = null;
        /// <summary>
        /// Elapsed time in milliseconds.
        /// </summary>
        public int ElapsedMilliseconds {
            get {
                if (_elapsedMilliseconds == null) {
                    _elapsedMilliseconds = Stopwatch.StartNew();
                }
                return (int)_elapsedMilliseconds.ElapsedMilliseconds;
            }
        }
        /// <summary>
        /// Elapsed time in percentages.
        /// </summary>
        protected float Elapsed {
            get {
                if (ElapsedMilliseconds >= Duration) {
                    return 1.0F;
                }
                float elapsed = (float)ElapsedMilliseconds / (float)Duration;
                if (elapsed >= 1.0F) {
                    return 1.0F;
                }
                return elapsed;
            }
        }
    }

    public class Transition : TransitionBase {
        public static readonly int FrameMilliseconds = 15;

        public Transition(object target, Double from, Double to) 
            : base(target, from, to) { 
        }
        
        public Transition(object target, Double from, Double to, int duration)
            : base(target, from, to, duration) {
        }

        /// <summary>
        /// Event signaling the start of this transition.
        /// </summary>
        protected virtual void OnStart() {
            ITransitionTarget target = this.Target as ITransitionTarget;
            if (target != null) {
                target.OnStart(this);
            }
        }
        /// <summary>
        /// Event signaling the completiong of this transition.
        /// </summary>
        protected virtual void OnCompleted() {
            ITransitionTarget target = this.Target as ITransitionTarget;
            if (target != null) {
                target.OnCompleted(this);
            }
        }
        /// <summary>
        /// Event signaling a change in value.
        /// </summary>
        protected virtual void OnChanged() {
            ITransitionTarget target = this.Target as ITransitionTarget;
            if (target != null) {
                target.OnChanged(this);
            }
        }

        System.Timers.Timer _frameTimer = null;
        /// <summary>
        /// Event signaling a change in value.
        /// </summary>
        protected void SetInterval(int milliseconds, System.Timers.ElapsedEventHandler elapsed) {
            if (_frameTimer != null) {
                _frameTimer.Dispose();
                _frameTimer = null;
            }
            if (elapsed != null && milliseconds > 0) {
                _frameTimer = new System.Timers.Timer(milliseconds);
                _frameTimer.Elapsed += elapsed;
                _frameTimer.Enabled = true;
            }
        }

        /// <summary>
        /// Easing function.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float EaseInOut(float t) {
            if ((t *= 2) < 1) return (float)(-(Math.Sqrt(1 - t * t) - 1) / 2);
            return (float)((Math.Sqrt(1 - (t -= 2) * t) + 1) / 2);
        }

        /// <summary>
        /// Caluclates new value.
        /// </summary>
        public static Double Interpolate(Double from, Double to, Double completed) {
            return from + ((to - from) * completed);
        }

        /// <summary>
        /// Starts the animation.
        /// </summary>
        public void Start() {
            _value = _from;
            OnStart();
            OnChanged();
            SetInterval(FrameMilliseconds, (sender, e) => {
                if (ElapsedMilliseconds >= Duration) {
                    if (_elapsedMilliseconds != null) {
                        _elapsedMilliseconds.Stop();
                    }
                    SetInterval(0, null);
                    _value = _to;
                    OnChanged();
                    OnCompleted();
                    return;
                }
                float completed = EaseInOut(Elapsed);
                _value = Interpolate(_from, _to, completed);
                OnChanged();
            });
        }

        /// <summary>
        /// Stops the animation.
        /// </summary>
        public void Stop() {
            if (_elapsedMilliseconds != null) {
                _elapsedMilliseconds.Stop();
            }
            SetInterval(0, null);
        }
    }
}