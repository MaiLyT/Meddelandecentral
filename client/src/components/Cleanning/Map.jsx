import '../Cleanning/Map.css'
import { useState, useContext, useEffect } from 'react';
import ClearIcon from '@mui/icons-material/Clear';
import ErrorOutlineIcon from '@mui/icons-material/ErrorOutline';
import { pink, green, deepOrange } from '@mui/material/colors';
import { AppContext } from '../../Data';
import DescribeText from '../DescribeText';

export default function Map(){
    const { rooms, sendRoomCleaning} =useContext(AppContext);

    const toggleClean = event =>{
        let id= event.currentTarget.id;
        let clickedRoom = rooms[id-1];
        clickedRoom.isCleaned = !clickedRoom.isCleaned;
        sendRoomCleaning(id, clickedRoom.isCleaned);
    }

    const RenderOneRoom = (room) => {
        const className = `room room-${room.id}`
        return(
        <div className={className} key={room.id} id={room.id} onClick={toggleClean}>
            <div className="door-hor"></div>
            <div className="window-hor"></div>
            <div className="name">{room.roomName}</div>
            {room.isCleaned? <ClearIcon  sx={{ fontSize: 70, color:green[700] }}/>: <ErrorOutlineIcon sx={{ fontSize: 70, color: pink[500]}}/>}
        </div>
        )
    }

    const RenderAllRooms = (rooms) => {
        return rooms.map(room => RenderOneRoom(room));
    }

    return(
        <>
            <div className="main-content">
                {RenderAllRooms(rooms)} 

                <div className="corridor">
                    <div className="rug"></div>
                    <div className="window-ver"></div>
                    <div className="name">Corridor </div>
                </div>

                <div className='reception'>
                    <div className="rug"></div>
                    <div className="table"></div>
                    <div className="reception-chair"></div>
                    <div className="reception-chair"></div>
                    <div className='island'></div>
                    <div className="name">reception</div>

                </div>

                <div className="patio">
                    <div className="door-sliding"></div>
                    <div className="real-patio">
                    <div className="name">Entrén</div>
                </div>
                </div>
            </div>
            <DescribeText />
        </>
    )
}

