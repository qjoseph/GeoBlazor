﻿import Graphic from "@arcgis/core/Graphic";
import {DotNetGeometry, DotNetPopupTemplate} from "./definitions";
import {buildJsGeometry, buildJsPopupTemplate} from "./jsBuilder";
import Geometry from "@arcgis/core/geometry/Geometry";
import {buildDotNetGeometry, buildDotNetPopupTemplate} from "./dotNetBuilder";
import {arcGisObjectRefs} from "./arcGisJsInterop";

export default class GraphicWrapper {
    private graphic: Graphic;

    constructor(graphic: Graphic) {
        this.graphic = graphic;
        // set all properties from graphic
        for (let prop in graphic) {
            if (graphic.hasOwnProperty(prop)) {
                this[prop] = graphic[prop];
            }
        }
    }

    setAttribute(name: string, value: any): void {
        this.graphic.attributes[name] = value;
    }

    getAttribute(name: string): any {
        return this.graphic.attributes[name];
    }

    removeAttribute(name: string): void {
        delete this.graphic.attributes[name];
    }

    setGeometry(geometry: DotNetGeometry): void {
        let jsGeometry = buildJsGeometry(geometry);
        this.graphic.geometry = jsGeometry as Geometry;
    }

    getGeometry(): DotNetGeometry | null {
        return buildDotNetGeometry(this.graphic.geometry);
    }

    setSymbol(symbol: any): void {
        this.graphic.symbol = symbol;
    }

    getSymbol(): any {
        return this.graphic.symbol;
    }

    setVisibility(visible: boolean): void {
        this.graphic.visible = visible;
    }

    getVisibility(): boolean {
        return this.graphic.visible;
    }

    setPopupTemplate(popupTemplate: DotNetPopupTemplate, viewId: string): void {
        this.graphic.popupTemplate = buildJsPopupTemplate(popupTemplate, viewId);
    }

    getPopupTemplate(): DotNetPopupTemplate | null {
        return buildDotNetPopupTemplate(this.graphic.popupTemplate);
    }

    registerWithId(id: string): void {
        if (arcGisObjectRefs[id] !== this.graphic) {
            arcGisObjectRefs[id] = this.graphic;
        }
    }
}