import { useContext } from "react";
import Message from "./Message";
import { AppContext } from "../../Data";

export default function ChatWindow(){
    const {chat} = useContext(AppContext);
            const currentChat = chat
                .map(m => <Message 
                    key={Date.now() * Math.random()}
                    user={m.user}
                    message={m.message}/>);

    return(
        <div>
            {currentChat}
        </div>
    )
}