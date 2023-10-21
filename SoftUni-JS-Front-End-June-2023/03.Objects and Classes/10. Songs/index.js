function solve(text) {
    let n = Number(text.shift());
    let songs = [];
    for (let i = 0; i < n; i++) {
        let [typeList, name, time] = text.shift().split('_');
        let song = {
            typeList,
            name,
            time
        }
        songs.push(song);
    }
    let typeList = text.shift();
    if (typeList === 'all') {
        songs.forEach((i) => console.log(i.name));
    } else {
        let filtered = songs.filter((i) => i.typeList === typeList);
        filtered.forEach((i) => console.log(i.name));
    }
}
solve([3, 
    'favourite_DownTown_3:14', 
    'favourite_Kiss_4:16', 
    'favourite_Smooth Criminal_4:01', 
    'favourite'] );//DownTown 
    // Kiss 
    // Smooth Criminal 
solve([4,
    'favourite_DownTown_3:14',
    'listenLater_Andalouse_3:24',
    'favourite_In To The Night_3:58',
    'favourite_Live It Up_3:48',
    'listenLater']);//Andalouse
solve([2,
    'like_Replay_3:15', 
    'ban_Photoshop_3:48', 
    'all'] );//Replay
    // Photoshop


