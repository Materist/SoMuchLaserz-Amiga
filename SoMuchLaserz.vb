      MAKS=0
   End If 

   Ink KOL,7,
   Wait Vbl 
   Wait Vbl 
   Text X,Y,MSG$


End Proc[KOL]

Procedure SPLASHSCREEN
   BUTFIRE=0
   KOL=0
   Load Iff "asm:GrafikiLaserz/INTRO.PIC",5
   Load "asm:GrafikiLaserz/MegaMen/bobek",14
   Channel 1 To Bob 1
   Bob 1,200,200,1
   Anim 1,"(1,60) (2,15)L"
   Anim On 
   Load "AMOS_BANK:AMOS_Music/Music_Draconus.ABK",3
   Music 1
   Repeat 
      CHECKFIRE
      BUTFIRE=Param
      KOLTEXT[KOL,0,16,80,150,"PRESS START BUTTON"]
      KOL=Param
   Until BUTFIRE=1
   Erase All 
   BUTFIRE=0
   LDSCR
End Proc


