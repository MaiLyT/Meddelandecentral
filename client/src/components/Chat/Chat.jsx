import ChatInput from "./ChatInput";
import ChatWindow from "./ChatWindow";

export default function Chat(){
    return(
        <div className="chat">
            <ChatInput />
            <ChatWindow />
        </div>
    )
}