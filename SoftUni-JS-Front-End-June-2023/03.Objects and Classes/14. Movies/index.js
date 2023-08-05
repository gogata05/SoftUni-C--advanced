function solve(arrayMovies) {
    let movies = [];
    for (let i = 0; i < arrayMovies.length; i++) {
        let movie = {};
        if (arrayMovies[i].includes('addMovie')) {
            let name = arrayMovies[i].split('addMovie ')[1];
            movie.name = name;
            movies.push(movie);
        } else if (arrayMovies[i].includes('directedBy')) {
            let [name, director] = arrayMovies[i].split(' directedBy ');
            for (let movie of movies) {
                if (movie.name === name) {
                    movie.director = director;
                }
            }
        } else if (arrayMovies[i].includes('onDate')) {
            let [name, date] = arrayMovies[i].split(' onDate ');
            for (let movie of movies) {
                if (movie.name === name) {
                    movie.date = date;
                }
            }
        }
    }
    for (let movie of movies) {
        if (movie.name && movie.director && movie.date) {
            console.log(JSON.stringify(movie));
        }
    } 
}
solve([ 
    'addMovie Fast and Furious',
    'addMovie Godfather', 
    'Inception directedBy Christopher Nolan', 
    'Godfather directedBy Francis Ford Coppola', 
    'Godfather onDate 29.07.2018', 
    'Fast and Furious onDate 30.07.2018', 
    'Batman onDate 01.08.2018', 
    'Fast and Furious directedBy Rob Cohen' 
    ])
    // {"name":"Fast and Furious","date":"30.07.2018","director":"Rob Cohen"} 
    // {"name":"Godfather","director":"Francis Ford Coppola","date":"29.07.2018"}    
solve([
    'addMovie The Avengers', 
    'addMovie Superman', 
    'The Avengers directedBy Anthony Russo', 
    'The Avengers onDate 30.07.2010', 
    'Captain America onDate 30.07.2010', 
    'Captain America directedBy Joe Russo' 
    ]);
    // {"name":"The Avengers","director":"Anthony Russo","date":"30.07.2010"}
