﻿using Simcorp.IMS.Phone.Battery;
using Simcorp.IMS.Phone.Speaker;
using Simcorp.IMS.Phone.Keyboard;
using Simcorp.IMS.Phone.Microphone;
using Simcorp.IMS.Phone.Screen;
using Simcorp.IMS.Phone.SimCard;
using System.Text;

namespace Simcorp.IMS.Phone {
    public abstract class BaseMobile {
        public abstract string ModelName { get; }
        public abstract BaseBattery Battery { get; }
        public abstract BaseSpeakerSystem Speaker { get; }
        public abstract BaseKeyboard KeyBoard { get; }
        public abstract BaseMicrophone Microphone { get; }
        public abstract BaseScreen Screen { get; }
        public abstract BaseSimCardSlot SimCard { get; }

        private void Show(IScreenable screenImage) {
            Screen.Show(screenImage);
        }

        private void FetchNetwork() {
            SimCard.GetSimCardInfo();
        }

        private void FetchSound(IFetchSound sound) {
            Microphone.FetchSound(sound);
        }

        private void ReproduceSound(IReproduceSound sound) {
            Speaker.ReproduceSound(sound);
        }
        private void ReproduceSound(IReproduceSound sound1, IReproduceSound sound2)
        {
            Speaker.ReproduceSound(sound1, sound2);
        }

        private void Charge(double energy) {
            Battery.Charge(energy);
        }

        private void GiveCharge(double energy) {
            Battery.GiveCharge(energy);
        }

        public virtual string GetDescription() {
            var descriptionBuilder = new StringBuilder();
            descriptionBuilder.AppendLine($"Model name: {ModelName}");
            descriptionBuilder.AppendLine($"{Battery.ToString()}");
            descriptionBuilder.AppendLine($"{Speaker.ToString()}");
            descriptionBuilder.AppendLine($"Keyboard type : {KeyBoard.ToString()}");
            descriptionBuilder.AppendLine($"Microphone : {Microphone.ToString()}");
            descriptionBuilder.AppendLine($"Sim card : {SimCard.ToString()}");
            descriptionBuilder.AppendLine($"{Screen.ToString()}");
            return descriptionBuilder.ToString();
        }
    }
}