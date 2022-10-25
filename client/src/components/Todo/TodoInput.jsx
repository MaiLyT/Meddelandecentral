import  React, {useContext, useState}  from 'react'
import { AppContext } from '../../Data';

export default function TodoInput(props){

    const [notis, setNotis] = useState('');
    const {sendNewTodo} = useContext(AppContext);

    const onSubmit = (e) => {
        e.preventDefault();
        const isNotisProvided = notis && notis !== '';

        if(isNotisProvided){
            sendNewTodo((props.roomId), notis);
            setNotis('');
        }else{
            alert('Notis field can not be empty');
        }
    }

    const onNotisUpdate= (e) => {
        setNotis(e.target.value);
    }

    return (
        <form onSubmit={onSubmit} className='newNotis'>            
            <input 
                className='field'
                placeholder='  Add new notis'
                label="notis" 
                type='text'
                name='notis'
                value={notis}
                onChange = {onNotisUpdate} />
            {/* <button className='button'> Send </button> */}

        </form>
    )
}