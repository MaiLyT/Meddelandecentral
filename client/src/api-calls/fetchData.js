import axios from 'axios';

async function getRoomsInfo(setRooms){
    return await axios({
        method: "get",
        url: 'https://localhost:5001/Room',
        
    })
        .then((res) => {
            setRooms(res.data);
            return res.data;
        })
        .catch((error) => {
        console.log(error);
        });
    }

async function getAllTodos(setTodos){
    return await axios({
        method: "get",
        url: 'https://localhost:5001/Todo',
        
    })
        .then((res) => {
            setTodos(res.data);
            return res.data;
        })
        .catch((error) => {
        console.log(error);
        });
    }    

async function sendRoomCleaning(id, isCleaned){
    await axios({
        method:'POST',
        url:'https://localhost:5001/Room',
        data:{
            Id: id,
            isCleaned:isCleaned
        },
    })
    .then((res) => {
        console.log('success update room cleaning',res);
    })
    .catch((error) => {
    console.log('Update room cleaning error: ',error);
    });
}

export { getRoomsInfo, sendRoomCleaning, getAllTodos, }