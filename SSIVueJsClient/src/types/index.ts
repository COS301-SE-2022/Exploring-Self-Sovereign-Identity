import type { NONE } from "src/utils/constant";

export type None = typeof NONE;

import type {
  BeardShape,
  ClothesShape,
  EarringsShape,
  EarShape,
  EyebrowsShape,
  EyesShape,
  FaceShape,
  Gender,
  GlassesShape,
  MouthShape,
  NoseShape,
  TopsShape,
  WrapperShape,
} from "src/enums/index";

interface Widget<Shape> {
  shape: Shape | None;
  zIndex?: number;
  fillColor?: string;
  strokeColor?: string;
}

type AvatarWidgets = {
  face: Widget<FaceShape>;
  tops: Widget<TopsShape>;
  ear: Widget<EarShape>;
  earrings: Widget<EarringsShape>;
  eyebrows: Widget<EyebrowsShape>;
  glasses: Widget<GlassesShape>;
  eyes: Widget<EyesShape>;
  nose: Widget<NoseShape>;
  mouth: Widget<MouthShape>;
  beard: Widget<BeardShape>;
  clothes: Widget<ClothesShape>;
};

export interface AvatarOption {
  gender?: Gender;

  wrapperShape?: `${WrapperShape}`;

  background: {
    color: string;
  };

  widgets: Partial<AvatarWidgets>;
}

export interface AvatarSettings {
  gender: [Gender, Gender];

  wrapperShape: WrapperShape[];
  faceShape: FaceShape[];
  topsShape: TopsShape[];
  earShape: EarShape[];
  earringsShape: EarringsShape[];
  eyebrowsShape: EyebrowsShape[];
  eyesShape: EyesShape[];
  noseShape: NoseShape[];
  mouthShape: MouthShape[];
  beardShape: BeardShape[];
  glassesShape: GlassesShape[];
  clothesShape: ClothesShape[];

  commonColors: string[];
  backgroundColor: string[];
  skinColor: string[];
}
