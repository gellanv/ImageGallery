import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  public CopyrightText: string = '© 2021 Copyright: NadinVGS';
  constructor() { }
  ngOnInit(): void { }
}
