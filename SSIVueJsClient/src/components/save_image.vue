<template>
  <div>
    <img
      class="random download-img"
      @click="saveImage"
      :src="require('../assets/img/download.svg')"
    />
  </div>
</template>

<script lang="ts">
import Canvg from "canvg";

export default {
  name: "SaveImage",
  methods: {
    /**
     *
     *
     * @param {string} imageURL
     */
    downloadImage(imageURL) {
      const downloadLink = document.createElement("a");
      downloadLink.href = imageURL;
      downloadLink.download = "avatar.png";
      document.body.appendChild(downloadLink);
      downloadLink.dispatchEvent(
        new MouseEvent("click", {
          bubbles: true,
          cancelable: true,
          view: window,
        })
      );

      document.body.removeChild(downloadLink);
    },

    async saveImage() {
      let combinedSvg =
        '<div id="avatar" style="position:relative;width:100%;height:100%;"><svg width="360px" height="360px" viewBox="0 0 360 360" style="position: absolute;width: 100%;height: 100%;">';

      const addIfAvailable = (element) => {
        if (element !== undefined && element !== null) {
          combinedSvg = combinedSvg + element.outerHTML;
        }
      };

      const avatarDiv = document.querySelector("#avatar");
      addIfAvailable(
        avatarDiv.querySelector("#skinColor").querySelector(".show")
      );
      addIfAvailable(
        avatarDiv.querySelector("#tattoos").querySelector(".show")
      );
      addIfAvailable(
        avatarDiv.querySelector("#accesories").querySelector(".show")
      );
      addIfAvailable(
        avatarDiv.querySelector("#clothes").querySelector(".show")
      );
      addIfAvailable(
        avatarDiv.querySelector("#eyebrows").querySelector(".show")
      );
      addIfAvailable(avatarDiv.querySelector("#eyes").querySelector(".show"));
      addIfAvailable(avatarDiv.querySelector("#mouths").querySelector(".show"));
      addIfAvailable(avatarDiv.querySelector("#hair").querySelector(".show"));
      addIfAvailable(
        avatarDiv.querySelector("#facialhair2").querySelector(".show")
      );
      addIfAvailable(
        avatarDiv.querySelector("#glasses").querySelector(".show")
      );

      combinedSvg = combinedSvg + "</svg></div>";

      const canvas = document.createElement("canvas");
      canvas.width = 1200;
      canvas.height = 1200;
      const ctx = canvas.getContext("2d");
      const drawn = Canvg.fromString(ctx, combinedSvg);

      await drawn.render();

      this.downloadImage(canvas.toDataURL("image/png"));
    },
  },
};
</script>
