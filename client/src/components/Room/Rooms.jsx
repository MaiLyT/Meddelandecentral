import { useContext } from 'react';
import ClearIcon from '@mui/icons-material/Clear';
import CheckCircleOutlineIcon from '@mui/icons-material/CheckCircleOutline';
import { pink, green, blue } from '@mui/material/colors';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import { AppContext } from '../../Data';
import './Room.css';
import TodoInput from '../Todo/TodoInput';
import DescribeText from '../DescribeText';
import RenderOneRoom from './RenderOneRoom'

export default function Rooms(){
    const { rooms, sendRoomCleaning, sendUpdateTodo, colorList} =useContext(AppContext);
    return(
        <div className='rooms'>
            {rooms.map(room => RenderOneRoom(room))}
            <DescribeText />
        </div>

    )
}   
