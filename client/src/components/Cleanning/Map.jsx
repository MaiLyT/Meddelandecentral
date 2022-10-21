import '../Cleanning/Map.css'
import { useState } from 'react';
import ClearIcon from '@mui/icons-material/Clear';
import ErrorOutlineIcon from '@mui/icons-material/ErrorOutline';
import { pink, red, blue, green } from '@mui/material/colors';

export default function Map(){
    const [isCleaned, setIsCleaned]= useState('false');

    const rooms = document.getElementsByClassName('room');

    const roomNameList = [];
    for(let i = 0; i<rooms.length; i++) {
        otherClassName = rooms[i].classList[1]
        roomNameList.push(otherClassName)
    }
    console.log(roomNameList)
    const toggleClean = () =>{
        setIsCleaned(prev => !prev);
    }
    return(
        <>
            <div class="main-content">
                <div onClick={toggleClean} class="room room-6">
                    <div class="door-hor"></div>
                    <div class="window-hor"></div>
                    <div class="name">room 6</div>
                    {isCleaned? <ClearIcon sx={{ fontSize: 70, color:green[700] }}/>: <ErrorOutlineIcon sx={{ fontSize: 80, color: pink[500]}}/>}
                </div>
                <div class="room room-4">
                    <div class="door-hor"></div>
                    <div class="window-hor"></div>
                    <div class="name">room 4</div>
                    {isCleaned? <ClearIcon sx={{ fontSize: 70, color:green[700] }}/>: <ErrorOutlineIcon sx={{ fontSize: 80, color: pink[500]}}/>}

                </div>
                <div class="room room-2">
                    <div class="door-hor"></div>
                    <div class="window-hor"></div>
                    <div class="name">room 2</div>
                    {isCleaned? <ClearIcon sx={{ fontSize: 70, color:green[700] }}/>: <ErrorOutlineIcon sx={{ fontSize: 80, color: pink[500]}}/>}

                </div>
                <div class="room room-conference">
                    <div class="door-hor"></div>
                    <div class="window-hor"></div>
                    <div class="name">Conference </div>
                    {isCleaned? <ClearIcon sx={{ fontSize: 70, color:green[700] }}/>: <ErrorOutlineIcon sx={{ fontSize: 80, color: pink[500]}}/>}
                </div>
                <div class="corridor">
                    <div class="rug"></div>
                    <div class="window-ver"></div>
                    <div class="name">Reception </div>
                    <div class="table"></div>
                    <div class="corridor-chair"></div>
                    <div class="corridor-chair"></div>
                    <div class='island'></div>
                </div>
                <div class="room room-v1">
                    <div class="door-hor"></div>
                    <div class="window-hor"></div>
                    <div class="name">room 5</div>
                    {isCleaned? <ClearIcon className='icon' sx={{ fontSize: 70, color:green[700] }}/>: <ErrorOutlineIcon sx={{ fontSize: 80, color: pink[500]}}/>}
                </div>
                <div class="room room-v2">
                    <div class="door-hor"></div>
                    <div class="window-hor"></div>
                    <div class="name">room 3</div>
                    {isCleaned? <ClearIcon sx={{ fontSize: 70, color:green[700] }}/>: <ErrorOutlineIcon sx={{ fontSize: 80, color: pink[500]}}/>}
                </div>
                <div class="room room-v3">
                    <div class="door-hor"></div>
                    <div class="window-hor"></div>
                    <div class="name">room 1</div>
                    {isCleaned? <ClearIcon sx={{ fontSize: 70, color:green[700] }}/>: <ErrorOutlineIcon sx={{ fontSize: 80, color: pink[500]}}/>}
                </div>
                <div class="patio">
                    <div class="door-sliding"></div>
                    <div class="real-patio">
                    <div class="name">Entrén</div>
                </div>
                </div>
            </div>
        </>
    )
}

