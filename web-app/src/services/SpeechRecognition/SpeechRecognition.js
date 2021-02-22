import { delay } from "../../utils/delay";

export class SpeechRecognition {
  constructor() {
    this.recognition = new webkitSpeechRecognition();
    this.recognition.lang = "en-US";
    this.recognition.continuous = true;
    this.results = []
    this.onResultHandler = this.onResult.bind(this)
  }

  start() {
    this.subscribeEvents();
    this.recognition.start();
  }

  stop() {
    this.recognition.stop();

    return delay(1000)
      .then(() => this.unsubscribeEvents())
  }

  text() {
    return this.results.join(" ")
  }

  subscribeEvents() {
    this.recognition.addEventListener("result", this.onResultHandler)
  }

  unsubscribeEvents() {
    this.recognition.removeEventListener("result", this.onResultHandler)
  }

  onResult(e) {
    this.results = Array
      .from(e.results)
      .map(r => r[0].transcript)
  }
}
