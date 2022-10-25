import { useContext } from 'react';
import ClearIcon from '@mui/icons-material/Clear';
import ErrorOutlineIcon from '@mui/icons-material/ErrorOutline';
import { pink, green } from '@mui/material/colors';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import { AppContext } from '../../Data';
import './Room.css';
import TodoInput from '../Todo/TodoInput';
import DescribeText from '../DescribeText';

export default function Rooms(){
    const { rooms, sendRoomCleaning, sendUpdateTodo} =useContext(AppContext);

    const colorList = ['#F7DA66', '#F5AFA3', '#75D7F0', '#85E0A3', '#80CAFF', '#AFBCCF']

    const toggleClean = (event) => {
        let id= parseInt(event.currentTarget.id);
        let clickedRoom = rooms[id-1];
        let status = !clickedRoom.isCleaned;
        sendRoomCleaning(id, status);
    }

    const toggleDone = (event, isFinished) =>{
        let id = event.currentTarget.id;
        let status = !isFinished;
 
        sendUpdateTodo(id, status);
    }

    function RenderOneNotis(notis){
        let isFinished = notis.isDone;
        return (
            <div className="notis" key={notis.id} id={notis.id} onClick={e => toggleDone(e, isFinished)}>
                {/* {isFinished &&<FormControlLabel control={<Checkbox defaultChecked />} label={notis.notis} />} */}
                {!isFinished &&<FormControlLabel control={<Checkbox />} label={notis.notis} />}
            </div>
        )
    }

    function RenderOneRoom(room){
        const className = `roomFlex room${room.id}`
        let bgColor = { backgroundColor: colorList[(room.id)-1] }
        
        return(
            <div className={className} key={room.id} style={bgColor} >                
                <div className='icon' id={room.id}room_icon onClick={toggleClean}>
                    {room.isCleaned? 
                        <ClearIcon sx={{fontSize: 70, color: green[700]}}/>
                        :<ErrorOutlineIcon sx={{fontSize: 70, color: pink[500]}}/>
                    }
                </div>
                <div className="roomName" id={room.id}room_name onClick={toggleClean}>{room.roomName}</div>
                {(room.todo).length==0? 'No notis found!' : (room.todo).map(tdo => RenderOneNotis(tdo))}
                <TodoInput roomId={room.id}/>
            </div>
        )
    }

    return(
        <div className='rooms'>
            {rooms.map(room => RenderOneRoom(room))}
            <DescribeText />
        </div>

    )
}   
