using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Util {
    public class InputListener {
        private Keys _key;
        private Action<KeyEventArgs> _onInput;

        public InputListener(Keys key, Action<KeyEventArgs> onInput) {
            _key = key;
            _onInput = onInput;
            Register();
        }

        public Keys ListensFor() {
            return _key;
        }

        public void OnInput(KeyEventArgs input) {
            _onInput.Invoke(input);
        }

        private void Register() {
            InputHandler.Singleton.AddInputListener(this);
        }

    }
}
