import { Speaker }from "services/Speaker";

export function useSpeaker() {
  const speak = (text) => {
    Speaker.say(text)
  }

  return {
    speak
  }
}
