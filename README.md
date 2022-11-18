# Agoraphobos Videogame 

## Can you Escape ?

## Integrantes 

- Eugenia Sol Piñeiro - 59449 
- Lucía Torrusio      - 59489 
- Luciano Boccardi    - 59518

## Features y Diseño TP2 
Se desarrolló un escape room que cuenta con 4 niveles/habitaciones: Library, Bedroom, Kitchen y Hall:
- Se agregó la instanciación de enemigos (Spider y Rat) siguiendo los patrones Factory y Flyweight 
- Se aplicaron animaciones con Animator hechas por nosotros (SecretDoor y Chandelier en Library, y MansionDoor en la puerta final de la mansión)
- Se aplicaron animaciones por código como Spider, Rat, Doors, Chests, Valves 
- Se agregó una barra de vida en el Hud
- Se agregó una escena async de carga de nivel 
- Se incorporó Particle Systems para el fuego de la Library y los fuegos artificiales que aparecen cuando se gana el fuego. 
- Se utiliza Raycasting para interactuar con todos los objetos.
- Se agregaron efectos de luces (light probe groups, color space linear, point lights, directional light proveniente del mismo lugar que el sol del skybox, elementos estáticos y materiales emissive). 

## Features y Diseño TP1 
Se desarrolló un escape room que cuenta con 2 niveles/habitaciones: Library y Bedroom: 
- Se organizaron los Assets en carpetas junto con los Prefabs respectivos para cada objeto. 
- Componentes que apliquen movimiento, rotación (Character), instanciación (las piezas de ajedrez se instancian) y/odestrucción (hay objetos que se destruyen una vez que interactúa con ellos, como por ejemplo Chandelier y SecretDoor).
- Se integraron texturas y audio: música de fondo y SFX para cuando se gana o pierde, cuando se abre una puerta, cuando se interactúa con un objeto y cuando se desbloquea una puerta. 
- Se utilizó el componente cinemachine para el manejo de la cámara.
- Se utilizó el sistema de inputs para capturar las acciones del usuario/jugador (WASD para movimiento y rotación, E para interactuar y el mouse para cambiar la perspectiva de la cámra).
- Se implementaron colisiones y triggers. Por ejemplo, cuando se resuleve el puzzle las puertas pasan a ser triggers y si el jugador colisiona con ellas se abren. 
- Se siguieron distinton patrones de diseño. Strategy para interfaces como por ejemplo IInteractable, Command para el movimiento del jugador, Manager para event-subscribe por ejemplo triggerear alguna acción o SFX cuando se termina el juego y Flyweight por ejemplo para las variables compartidas entre puzzles (cantidad de pasos para resolverlo, número de nivel, puerta que se abren al resolverlo). 
- Se implementaron distintos eventos con Actions, por ejemplo OnPuzzleSolved, OnGameOver, OnStepSolved, entre otras. 
- Se cuenta con 4 escenes (Menu principal, Información sobre cómo jugar, la escena principal con las habitaciones y la escena de gameover que a través de global data se le informa al jugador si ganó o perdió cambiando ciertos sprites)
- Se cuenta con un Hud manejado por el UIManager que informa al usuario en qué nivel está, cuántos pasos le faltan para escapar de la habitación y cuánto tiempo le queda disponible antes de perder.


## SPOILER ALERT !! 
## Cómo resolver los puzzles

Para ver cómo resolver el juego adjuntamos un gameplay: 