export const Speaker = {
  say: (text) => {
    window.speechSynthesis.speak(
      utterance(text)
    );
  }
}

function utterance(text) {
  const utt = new SpeechSynthesisUtterance(text);
  utt.lang = "en-US";

  return utt;
}
