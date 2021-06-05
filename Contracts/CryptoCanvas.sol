// SPDX-License-Identifier: GPL-3.0
pragma solidity ^0.8.4;

contract Canvas {    

    // uint[65536] public canvasPixels;
    mapping(uint => uint) public pixels;

    function setPixel( uint _canvasIndex, uint _rgbColor ) public {
        pixels[_canvasIndex] = _rgbColor;
    }

    function getPixel( uint _canvasIndex ) public view returns (uint _rgbColor) {
        return pixels[_canvasIndex];
    }
}
