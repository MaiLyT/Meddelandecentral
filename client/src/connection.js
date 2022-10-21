import { useState, useEffect, useRef } from "react";
import { HubConnectionBuilder } from "@microsoft/signalr";

export default function connection(){
    const [chat, setChat] = useState([]);
    const latestChat = useRef(null);

    latestChat.current = chat;

    useEffect(()=>{
        const connection = new HubConnectionBuilder()
            .withUrl('https://localhost:5001/hubs/chat')
            .withAutomaticReconnect()
            .build();

            connection.start()
                .then(result =>{
                    console.log('Connected');

                    connection.on('ReceiveMessage', message =>{
                        const updatedChat = [message, ...latestChat.current];
                        setChat(updatedChat);
                    });
                })
                .catch(e => console.log('Connection failed: ', e));
        
    }, [])

    const sendMessage = async(user, msg) => {
        const chatMessage = {
            user: user,
            message: msg
        };
    
        try{
            await fetch('https://localhost:5001/Chat/messages', {
                method: 'POST',
                body:JSON.stringify(chatMessage),
                headers:{'Content-Type': 'application/json'}
            });
        }
        catch(e){console.log('Send msg error: ', e)}
    }

    return connection
}
