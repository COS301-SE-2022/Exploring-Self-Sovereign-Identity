export const enum ActionType {
  Undo = 'undo',
  Redo = 'redo',
  Flip = 'flip',
  Code = 'code',
}

export enum Gender {
  Male = 'male',
  Female = 'female',
  NotSet = 'notSet',
}

export enum WidgetType {
  Face = 'face',
  Tops = 'tops',
  Ear = 'ear',
  Earrings = 'earrings',
  Eyebrows = 'eyebrows',
  Eyes = 'eyes',
  Glasses = 'glasses',
  Mouth = 'mouth',
  Beard = 'beard',
  Clothes = 'clothes',
}

export enum WrapperShape {
  Circle = 'circle',
  Square = 'square',
  Squircle = 'squircle',
}

export enum FaceShape {
  Base = 'base',
  Purple = 'purple',
  Brown = 'brown',
  Black = 'black', 
}

export enum TopsShape {
  Fonze = 'fonze',
  Funny = 'funny',
  Clean = 'clean',
  Punk = 'punk',
  Danny = 'danny',
  Wave = 'wave',
  Turban = 'turban',
  Pixie = 'pixie',
  Beanie = 'beanie',
  None = 'none', 
}

export enum EarShape {
  Attached = 'attached',
  Detached = 'detached',
  None = 'none', 
}

export enum EarringsShape {
  Hoop = 'hoop',
  Stud = 'stud',
  Detached = 'detached',
  None = 'none',
}

export enum EyebrowsShape {
  Up = 'up',
  Eyelashesup = 'eyelashesup',
  Eyelashesdown = 'eyelashesdown',
  None = 'none',
}

export enum EyesShape {
  Ellipse = 'ellipse',
  Smiling = 'smiling',
  Eyeshadow = 'eyeshadow',
  Round = 'round',
  None = 'none', 
}


export enum MouthShape {
  Frown = 'frown',
  Nervous = 'nervous',
  Pucker = 'pucker',
  Sad = 'sad',
  Smile = 'smile',
  Smirk = 'smirk',
  Surprised = 'surprised',
  None = 'none', 
}

export enum BeardShape {
  Scruff = 'scruff',
  None = 'none',
}

export enum GlassesShape {
  Round = 'round',
  Square = 'square',
  None = 'none',
}

export enum ClothesShape {
  Crew = 'crew',
  Collared = 'collared',
  Open = 'open',
}

export type WidgetShape =
  | FaceShape
  | TopsShape
  | EarShape
  | EarringsShape
  | EyebrowsShape
  | EyesShape
  | MouthShape
  | BeardShape
  | GlassesShape
  | ClothesShape
