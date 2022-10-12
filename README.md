# Agoraphobos Videogame 

## Can you Escape ?

## Integrantes 

- Eugenia Sol Piñeiro - 59449 
- Lucía Torrusio      - 59489 
- Luciano Boccardi    - 59518

## Features y Diseño 
Se desarrolló un escape room que cuenta con 2 niveles/habitaciones: Library y Bedroom: 
- Se organizaron los Assets en carpetas junto con los Prefabs respectivos para cada objeto. 
- Componentes que apliquen movimiento, rotación (Character), instanciación (las piezas de ajedrez se instancian) y/odestrucción (hay objetos que se destruyen una vez que interactúa con ellos, como por ejemplo Chandelier y SecretDoor).
- Se integraron texturas y audio: música de fondo y SFX para cuando se gana o pierde, cuando se abre una puerta, cuando se interactúa con un objeto y cuando se desbloquea una puerta. 
- Se utilizó el componente cinemachine para el manejo de la cámara.
- Se utilizó el sistema de inputs para capturar las acciones del usuario/jugador (WASD para movimiento y rotación, E para interactuar y el mouse para cambiar la perspectiva de la cámra).
- Se implementaron colisiones y triggers. Por ejemplo, cuando se resuleve el puzzle las puertas pasan a ser triggers y si el jugador colisiona con ellas se abren. 
- Se siguieron distinton patrones de diseño. Strategy para interfaces como por ejemplo IInteractable, Command para el movimiento del jugador, Manager para event-subscribe por ejemplo triggerear alguna acción o SFX cuando se termina el juego y Flightweight por ejemplo para las variables compartidas entre puzzles (cantidad de pasos para resolverlo, número de nivel, puerta que se abren al resolverlo). 
- Se implementaron distintos eventos con actions, por ejemplo OnPuzzleSolved, OnGameOver, OnStepSolved. 
- Se cuenta con 4 escenes (Menu principal, Información sobre cómo jugar, la escena principal con las habitaciones y la escena de gameover que a través de global data se la informa al jugador si ganó o perdió cambiando ciertos sprites)
- Se cuenta con un Hud manejado por el UIManager que informa al usuario en qué nivel está, cuántos pasos le faltan para escapar de la habitación y cuánto tiempo le queda disponible antes de perder.

## Segunda Entrega 
A continuación se mencionan features que nos gustaría implementar para la segunda entrega (además de las consignas asignadas por la cátedra) 
- Hay un tercer nivel (Kitchen) que se encuentra en medio del desarrollo por lo que estará entregado para la siguiente entrega.
- Tener una mansión con más pisos donde cada piso sea un scene distinta (o cada habitación una scene distinta si es que se le agrega mucha complejidad a un único piso). Se puede ir cargando la mansión con escenas asincrónicas. Para la primera entrega no lo consideramos necesario porque solo tenemos dos habitaciones. 
- Cuando abras una habitación, encontrarse con algún enemigo. Por ejemplo, si vas al sótano podemos instanciar ratas, o si vas al ático murciélagos. De esta forma también podríamos tener una barra de vida el hud manejada con el LifeController.
- Scene de Settings para poder personalizar teclas de input, volumen de la música o desactivarla, pausar el juego, entre otros.   


## SPOILER ALERT !! 
## Cómo resolver los puzzles

Para ver cómo resolver el juego adjuntamos un gameplay: 