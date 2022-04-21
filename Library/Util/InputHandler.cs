using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Util {
    public class InputHandler {
        private static InputHandler instance = new InputHandler();
        public static InputHandler Singleton {
            get {
                return instance;
            }
        }
        private Dictionary<Keys, List<InputListener>> _listeners;

        private InputHandler() {
            _listeners = new Dictionary<Keys, List<InputListener>>();
        }

        public Dictionary<Keys, List<InputListener>> Listeners => _listeners;

        public void AddInputListener(InputListener listener) {
            if (!Listeners.ContainsKey(listener.ListensFor())) {
                _listeners[listener.ListensFor()] = new List<InputListener>();
            }
            _listeners[listener.ListensFor()].Add(listener);
        }
        public void HandleInput(KeyEventArgs input) {
            if (Listeners[input.KeyCode] != null) {
                foreach (InputListener il in Listeners[input.KeyCode]) {
                    il.OnInput(input);
                }
            }
        }
    }
}
