import React, { useState, useEffect, useRef, createContext } from "react";
import { HubConnectionBuilder } from "@microsoft/signalr";
import { getRoomsInfo } from "./api-calls/fetchData";
import axios from "axios";

export const AppContext = createContext();

export default function Data(props){
    const [chat, setChat] = useState([]);
    const [rooms, setRooms] = useState([]);
    const latestChat = useRef(null);
    const latestRooms = useRef(null);

    latestChat.current = chat;
    latestRooms.current = rooms;

    useEffect(()=>{
        getRoomsInfo(setRooms);

        const connection = new HubConnectionBuilder()
            .withUrl('https://localhost:5001/hubs/chat')
            .withAutomaticReconnect()
            .build();

            connection.start()
                .then(result =>{
                    //console.log('Connected');
                    connection.on('ReceiveMessage', message =>{
                        const updatedChat = [message, ...latestChat.current];
                
                        setChat(updatedChat);
                    });

                    connection.on('ReceiveRoomCleaning', ({id, isCleaned}) => {
                        let currRooms = [...latestRooms.current];
                        currRooms[id-1].isCleaned = isCleaned;
                        setRooms(currRooms);
                    })

                    connection.on('ReceiveNewTodo', newtodo =>{
                        let index = newtodo.roomId -1;
                        let currRooms = [...latestRooms.current];
                        currRooms[index].todo = [...currRooms[index].todo, newtodo];
                        
                        setRooms(currRooms);
                    })

                    connection.on('ReceiveUpdatedTodo', ({id, isDone}) =>{
                        let currRooms = [...latestRooms.current];  
                        let todosList = currRooms.map(room => (room.todo).map(tdo => {
                            if(tdo.id == id){
                                tdo.isDone = isDone;
                                return tdo;                              
                            }else{
                                return tdo;
                            }
                        }));    
                        for(let i = 0; i<currRooms.length; i ++){
                            currRooms[i].todo = todosList[i];
                        }            
                        // console.log("🚀 ~ file: Data.jsx ~ line 59 ~ updatedRooms ~ updatedRooms", currRooms)
                        
                        setRooms(currRooms);
                    })
                })
                .catch(e => console.log('Connection failed: ', e));
    }, [])

    const sendRoomCleaning = async(id, isCleaned) => {
        await axios({
            method:'POST',
            url:'https://localhost:5001/Room/cleaning',
            data:{
                Id: id,
                isCleaned: isCleaned
            },
        })
        .then((res) => {
            if(res.status == 200){
                //console.log('success',res);
            }
        })
        .catch((error) => {
        console.log('Update room cleaning error: ',error);
        });
    }

    const sendNewTodo = async(roomId, notis) => {
        await axios({
            method:'POST',
            url:'https://localhost:5001/Todo/create',
            data:{
                RoomId: roomId,
                Notis: notis,
            },
        })
        .then((res) => {
            if(res.status == 200){
                //console.log('success',res);
            }
        })
        .catch((error) => {
        console.log('Update todo error: ',error);
        });
    }

    const sendUpdateTodo = async(id, isDone) => {
        await axios({
            method:'POST',
            url:'https://localhost:5001/Todo/update',
            data:{
                Id: id,
                isDone:isDone
            },
        })
        .then((res) => {
            if(res.status == 200){
                // console.log('success',res);
            }
        })
        .catch((error) => {
        console.log('Update todo error: ',error);
        });
    }

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

    return(
        <>
            <AppContext.Provider
                value={{
                    sendMessage,
                    chat,
                    rooms,
                    sendRoomCleaning,
                    sendUpdateTodo,
                    sendNewTodo,
                }}
            >
                {props.children}
            </AppContext.Provider>
        </>
    );
};
