import  React, {useState}  from 'react'
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';

export default function ChatInput(props){
    let savedUsername = localStorage.getItem('username');
    let initUsername = savedUsername !== null ? localStorage.getItem('username'):'';
    const [user, setUser] = useState(initUsername);
    const [message, setMessage] = useState('');

    const isUserProvided = user && user !== '';
    const onSubmit = (e) => {
        e.preventDefault();

        //const isUserProvided = user && user !== '';
        const isMessageProvided = message && message !== '';

        if(isUserProvided && isMessageProvided){
            props.sendMessage(user, message);
            setMessage('');
        }else{
            alert('Pls insert an user and a message');
        }

    }
    const onUserUpdate = (e) => {
        let currentname = e.target.value
        localStorage.setItem('username', currentname);
        setUser(currentname);
    }

    const onMessageUpdate= (e) => {
        setMessage(e.target.value);
    }

    return (
        <form onSubmit={onSubmit}>
        {!isUserProvided && <>
                <label htmlFor='user'>User:</label>
                <br />
                <input 
                    id='user'
                    name='user'
                    value = {user}
                    onChange ={onUserUpdate} />
                <br />
            </>}
            
            <input
                className='field'
                label="Message" 
                type='text'
                id='message'
                name='message'
                value={message}
                onChange = {onMessageUpdate} />
            <button className='button'> Send </button>
        </form>
    )
}