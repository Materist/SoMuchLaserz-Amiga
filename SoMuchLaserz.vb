
OK=0
KOL=1

Gosub SPLASHSCREEN

MAINMENU:
   Load "AMOS_BANK:AMOS_Music/Music_Bumioh.ABK",15
   Load Iff "asm:GrafikiLaserz/LOADING.PIC",5
   Bank Swap 3,15
   Music 1
   Do 
      If Fire(1)
         Erase All 
         End 
      End If 
   Loop 

SPLASHSCREEN:
   Do 
      If OK=0
         Load Iff "asm:GrafikiLaserz/INTRO.PIC",5
         Load "AMOS_BANK:AMOS_Music/Music_Draconus.ABK",3
         Music 1
         OK=1
      Else 
      If KOL=16
         KOL=1
      End If 
         Ink KOL,0
         Text 80,150,"PRESS FIRE BUTTON"
         KOL=KOL+1
         If Fire(1)
            Erase 3
            Erase 5
            OK=0
            Gosub MAINMENU
         End If 
      End If 
      Wait 2
   Loop

