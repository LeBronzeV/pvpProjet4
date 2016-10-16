# pvpProjet4
un projet pvp MOBA en C#

fonctionnement:
	Deux joueurs, ayant les même capacitées, s'affronte dans une arène.
	le but est de détruire la base enemi grace à ses compétence et ses sbires.
	les sbires sont des IA qui parcour la map pour détruire la base adverse.
	le joueur possède 3 attaques:
		-un dash( clic droit de la sourie ou encore un bouton de la manette.)
		-une boule de feu (clic gauche de la sourie ou encore un autre bouton de la manette)
		-un sort de zone ou grenade (barre espace ou un troisième bouton de la manette)
	il se déplace avec zqsd ou le joystic de la manette( pour l'instant le joueur 2 se déplace avec oklm)
	la partie se termine quand l'un des deux a détruit le cristal adverse.

bug non résolu:
	-problème de fps qui Drop.
	-les barre de vie (elle ne s'oriente pas en fonction de la caméra).
	-respawn(le personnage tremble pendant quelque instant).
	
difficultées rencontrées
	-manipulation des IA (raycast pour attasquer).

bug résolu
	-pas de bug résolu sans comprendre pourquoi.

liste des asset
	faite:
		-map(arbre non compris
		-menu
		-particule(texture non comprise)
		-barre de vie
 	recup:
		-texture
		-arbre
		-sbire 
		-anim sbire